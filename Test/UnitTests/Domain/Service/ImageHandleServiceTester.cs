using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;
using Xunit;

namespace UnitTests.Domain.Service
{
    public class ImageHandleServiceTester
    {
        [Fact]
        public void SingalHandleTest()
        {
            ImageHandleService service = new ImageHandleService();

            var sourcefile = "D:\\Public\\AppStoreResources\\AppLogos\\_android_new_984_87984_729225_icon_72.png";
            var targetfiledir = "D:\\Public\\AppStoreResources\\AppLogo\\";
            service.CutForSquare(sourcefile, targetfiledir, 72, 100);
        }

        [Fact]
        public void HandleTest()
        {
            ImageHandleService service = new ImageHandleService();
            service.Handle();
        }

        [Fact]
        public void ImageNameCheckTest()
        {
            var fileInput = "E:\\Temp\\imageName.txt";
            var fileOutput = "E:\\Temp\\imageName2.txt";
            ImageHandleService service = new ImageHandleService();
            service.ImageNameCheck(fileInput, fileOutput);
        }

        [Fact]
        public void ResizeImageTest()
        {
            ImageHandleService service = new ImageHandleService();

            var input = "D:\\temp\\1111.jpg";
            var output = "D:\\temp\\1111-1.jpg";

            Size newSize = new Size(450, 300);
            Bitmap mg = new Bitmap(input);


            Bitmap bp = service.ResizeImage(mg, newSize);
            if (bp != null)
                bp.Save(output);
        }
    }
}
