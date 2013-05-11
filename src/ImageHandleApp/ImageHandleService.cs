using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ImageHandleApp
{
    public class ImageHandleService
    {
        public const string ORIGRINAL_IMAGE_DIR = "D:\\AppStoreResources\\AppLogos\\";
        //public const string ORIGRINAL_IMAGE_DIR = "D:\\AppStoreResources\\AppLogos\\";
        //public const string ORIGRINAL_IMAGE_DIR = "D:\\temp\\OriginImage\\";
        public const string TARGET_IMAGE_DIR = "D:\\temp\\TargetImage\\";
        public const int SIDE = 72;

        public void Handle()
        {
            var originDirectoryInfo = new DirectoryInfo(ORIGRINAL_IMAGE_DIR);
            var originFileList = originDirectoryInfo.GetFiles();
            var fileNamelist = new List<string>();
            var count = 1;
            var dicLogo = new Dictionary<int, string>();

            foreach (var item in originFileList)
            {
                var originFileUrl = string.Format("{0}{1}", ORIGRINAL_IMAGE_DIR, item.Name);
                var targetFileUrl = String.Format("{0}{1}", TARGET_IMAGE_DIR, item.Name);
                if (item.Length > 0)
                {
                    var fileName = item.Name;
                    var tt = fileName.Split('_');
                    var appId = tt[0];

                    Regex regNum = new Regex("^[0-9]");
                    if (regNum.IsMatch(appId) && item.Length >= 42 && tt.Length == 3)
                    {
                        var guidId = tt[1];
                        if (guidId.Length == 36)
                        {
                            SingalHandle(dicLogo, originFileUrl, targetFileUrl, count, appId);
                            count++;
                        }
                    }
                }
            }

            foreach (var item in originFileList)
            {
                var originFileUrl = string.Format("{0}{1}", ORIGRINAL_IMAGE_DIR, item.Name);
                var targetFileUrl = String.Format("{0}{1}", TARGET_IMAGE_DIR, item.Name);
                if (item.Length > 0)
                {
                    var fileName = item.Name;
                    var tt = fileName.Split('_');
                    var appId = tt[0];

                    Regex regNum = new Regex("^[0-9]");
                    if (regNum.IsMatch(appId) && item.Length >= 42 && tt.Length == 3)
                    {
                        var guidId = tt[1];
                        if (guidId.Length == 36)
                        {
                            CutForSquare(dicLogo, count, originFileUrl, targetFileUrl, appId);
                            count++;
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        public void SingalHandle(Dictionary<int, string> dic, string input, string output, int count, string appId)
        {
            string dir = Path.GetDirectoryName(output);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            Bitmap mg = new Bitmap(input);
            Size newSize = new Size(SIDE, SIDE);
            if (mg != null)
            {
                var flag = mg.Width - mg.Height;
                if (flag == 0)
                {
                    dic.Add(count, appId);
                    if (mg.Width > SIDE)
                    {
                        Bitmap bp = ResizeImage(mg, newSize);
                        if (bp != null)
                            bp.Save(output);
                        
                        Console.WriteLine(string.Format("The {0} image {1}x{2}: {3} is done.", count, mg.Width, mg.Height, output));
                    }
                }
            }
        }

        public void CutForSquare(Dictionary<int, string> dic, int count, string fileFormUrl, string fileSaveUrl, string appId, int side = 72, int quality = 100)
        {
            string dir = Path.GetDirectoryName(fileSaveUrl);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            System.Drawing.Image initImage = System.Drawing.Image.FromFile(fileFormUrl, true);
            var w = initImage.Width;
            var h = initImage.Height;

            if (initImage.Width != initImage.Height)
            {
                var isExist = dic.ContainsValue(appId);
                if (!isExist)
                {
                    int initWidth = initImage.Width;
                    int initHeight = initImage.Height;
                    if (initWidth != initHeight)
                    {
                        System.Drawing.Image pickedImage = null;
                        System.Drawing.Graphics pickedG = null;
                        if (initWidth > initHeight)
                        {
                            pickedImage = new System.Drawing.Bitmap(initHeight, initHeight);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                            pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            Rectangle fromR = new Rectangle((initWidth - initHeight) / 2, 0, initHeight, initHeight);
                            Rectangle toR = new Rectangle(0, 0, initHeight, initHeight);
                            pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                            initWidth = initHeight;
                        }
                        else
                        {
                            pickedImage = new System.Drawing.Bitmap(initWidth, initWidth);
                            pickedG = System.Drawing.Graphics.FromImage(pickedImage);
                            pickedG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            pickedG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            Rectangle fromR = new Rectangle(0, (initHeight - initWidth) / 2, initWidth, initWidth);
                            Rectangle toR = new Rectangle(0, 0, initWidth, initWidth);
                            pickedG.DrawImage(initImage, toR, fromR, System.Drawing.GraphicsUnit.Pixel);
                            initHeight = initWidth;
                        }
                        initImage = (System.Drawing.Image)pickedImage.Clone();
                        pickedG.Dispose();
                        pickedImage.Dispose();
                    }
                    System.Drawing.Image resultImage = new System.Drawing.Bitmap(side, side);
                    System.Drawing.Graphics resultG = System.Drawing.Graphics.FromImage(resultImage);
                    resultG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    resultG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    resultG.Clear(Color.White);
                    resultG.DrawImage(initImage, new System.Drawing.Rectangle(0, 0, side, side), new System.Drawing.Rectangle(0, 0, initWidth, initHeight), System.Drawing.GraphicsUnit.Pixel);
                    ImageCodecInfo[] icis = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo ici = null;
                    foreach (ImageCodecInfo i in icis)
                    {
                        if (i.MimeType == "image/jpeg" || i.MimeType == "image/bmp" || i.MimeType == "image/png" || i.MimeType == "image/gif")
                        {
                            ici = i;
                        }
                    }
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
                    resultImage.Save(fileSaveUrl, ici, ep);
                    ep.Dispose();
                    resultG.Dispose();
                    resultImage.Dispose();
                    initImage.Dispose();
                    Console.WriteLine(string.Format("The {0} image {1}x{2}: {3} is done.", count, w, h, fileSaveUrl));
                }
            }

        }

        public Bitmap ResizeImage(Bitmap mg, Size newSize)
        {
            double ratio = 0d;
            double myThumbWidth = 0d;
            double myThumbHeight = 0d;
            int x = 0;
            int y = 0;

            Bitmap bp;

            if ((mg.Width / Convert.ToDouble(newSize.Width)) > (mg.Height /
            Convert.ToDouble(newSize.Height)))
                ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(newSize.Width);
            else
                ratio = Convert.ToDouble(mg.Height) / Convert.ToDouble(newSize.Height);
            myThumbHeight = Math.Ceiling(mg.Height / ratio);
            myThumbWidth = Math.Ceiling(mg.Width / ratio);

            Size thumbSize = new Size((int)newSize.Width, (int)newSize.Height);
            bp = new Bitmap(newSize.Width, newSize.Height);
            x = (newSize.Width - thumbSize.Width) / 2;
            y = (newSize.Height - thumbSize.Height);
            System.Drawing.Graphics g = Graphics.FromImage(bp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle rect = new Rectangle(x, y, thumbSize.Width, thumbSize.Height);
            g.DrawImage(mg, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);

            return bp;

        }

        public void ImageFileSort()
        {
            Image oldImg = new Bitmap("d:/xxx.jpg");
            Image newImg = new Bitmap(oldImg.Width, oldImg.Height);

            Graphics g = Graphics.FromImage(newImg);
            g.DrawImage(oldImg, new Point(0, 0));

            newImg.Save("d:/new.jpg");
        }
    }
}
