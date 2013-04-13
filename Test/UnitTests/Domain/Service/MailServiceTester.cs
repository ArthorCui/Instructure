using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Service;
using Xunit;

namespace UnitTests.Domain.Service
{
    public class MailServiceTester
    {
        private static AutoResetEvent _event = new AutoResetEvent(false);

        [Fact]
        public void SendAsyncTest()
        {
            //ailService.SendAsync();
        }

        [Fact]
        public void MailAddressTest()
        {
            MailAddress MessageFrom = new MailAddress("arthor.cui@gmail.com");
            Console.WriteLine(MessageFrom.Address);
            Console.WriteLine(MessageFrom.Host);
            Console.WriteLine(MessageFrom.User);
            Console.WriteLine(MessageFrom.DisplayName);
        }

        private static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine((string)e.UserState);
            _event.Set();
        }
    }
}
