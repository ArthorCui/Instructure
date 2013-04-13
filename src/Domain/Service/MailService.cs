using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Const;
using NCore;
namespace Domain.Service
{
    public class MailService
    {
        private static AutoResetEvent _event = new AutoResetEvent(false);

        private string _date = DateTime.Now.AddDays(MailConfigKeys.MAIL_DAYS.ConfigValue().ToInt32()).ToString("yyyy-MM-dd");

        public void SendAsync()
        {
            var attachment = ExtractAttachment();
            var mailMessage = ExtractMailMessage(attachment);
            var smtpClient = ExtractSmtpClient(mailMessage);

            try
            {
                smtpClient.SendAsync(mailMessage, "OK");
                _event.WaitOne();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Attachment ExtractAttachment()
        {
            string path = string.Format("{0}{1} OTA统计详细.xls", MailConfigKeys.MAIL_ATTACHMENTFILEPATH.ConfigValue(), _date);
            try
            {
                var attachment = new Attachment(path, MediaTypeNames.Application.Octet);
                return attachment;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private SmtpClient ExtractSmtpClient(MailMessage mailMessage)
        {
            if (mailMessage != null)
            {
                var smtpClient = new SmtpClient();
                smtpClient.Credentials = new NetworkCredential(MailConfigKeys.MAIL_USER.ConfigValue(), MailConfigKeys.MAIL_PASSWORD.ConfigValue());
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                smtpClient.Host = MailConfigKeys.MAIL_HOST.ConfigValue();
                smtpClient.Port = MailConfigKeys.MAIL_PORT.ConfigValue().ToInt32();
                smtpClient.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                return smtpClient;
            }
            return null;
        }

        private MailMessage ExtractMailMessage(Attachment attachment)
        {
            var messagefromAddress = MailConfigKeys.MAIL_MESSAGEFROMADDRESS.ConfigValue();
            var messagetoAddress = MailConfigKeys.MAIL_MESSAGETOADDRESS.ConfigValue();
            MailAddress messageFrom = new MailAddress(messagefromAddress, "Arthor");
            MailAddress messageTo = new MailAddress(messagetoAddress, GetNickName(messagetoAddress));

            var mailMessage = new MailMessage(messageFrom, messageTo);
            var ccAddressString = MailConfigKeys.MAIL_MESSAGECCADDRESS.ConfigValue();
            if (!string.IsNullOrEmpty(ccAddressString))
            {
                var ccAddressList = ccAddressString.Split(',').ToList();
                foreach (var item in ccAddressList)
                {
                    mailMessage.CC.Add(new MailAddress(item, GetNickName(item)));
                }
            }
            mailMessage.CC.Add(messageFrom);

            mailMessage.Subject = string.Format("{0} OTA接口访问统计", _date);
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = MailConfigKeys.MAIL_MESSAGEBODY.ConfigValue();
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Attachments.Add(attachment);

            return mailMessage;
        }

        private string GetNickName(string mailAddress)
        {
            //Dictionary<string, string> nickDic = new Dictionary<string, string>();
            //nickDic.Add("cuijiequan", "Arthor");
            //nickDic.Add("jesuie.arthor","Jesuie");
            //nickDic.Add("yangxudong", "杨");
            //nickDic.Add("liujie", "刘捷");
            if (!string.IsNullOrEmpty(mailAddress))
            {
                var array =  mailAddress.Split('@');
                var nickName = array[0];
                //nickDic.TryGetValue(array[0], out nickName);
                return nickName;
            }
            return string.Empty;
        }

        private static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine((string)e.UserState);
            _event.Set();
        }

        private void Attachments(string Path)
        {
            string[] path = Path.Split(',');
            Attachment data;
            ContentDisposition disposition;
            for (int i = 0; i < path.Length; i++)
            {
                data = new Attachment(path[i], MediaTypeNames.Application.Octet);//实例化附件
                disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(path[i]);//获取附件的创建日期
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(path[i]);//获取附件的修改日期
                disposition.ReadDate = System.IO.File.GetLastAccessTime(path[i]);//获取附件的读取日期
                //mailMessage.Attachments.Add(data);//添加到附件中
            }
        }


    }
}
