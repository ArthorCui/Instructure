using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Service;

namespace MailAsyncApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            MailService ser = new MailService();
            ser.SendAsync();

        }
    }
}
