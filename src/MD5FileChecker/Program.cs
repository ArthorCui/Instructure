using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MD5FileChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cmd execute
            Console.WriteLine("Please input yout checker file path...");
            var input_Files = Console.ReadLine();
            args = new string[] { input_Files };
            if (args.Length == 0) throw new ArgumentException("Please specify one file...");
            var fileName = args[0];

            if (!File.Exists(fileName)) throw new FileNotFoundException("Can not find this file...");
            #endregion

            #region File Window Execute
            #endregion

            var file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            var sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }
}
