using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.Extensions;

namespace Domain.Service
{
    public class DataService
    {
        public string Encrypt(string Text)
        {
            int I;
            string encr = "";
            for (I = 1; I <= Text.Length; I++)
            {
                //encr = encr + Strings.Chr((Strings.Asc(Strings.Mid(Text, I, 1))) + 100);
            }
            return encr;

        }
        public string Decrypt(string Text)
        {
            int I;
            string dcr = "";
            for (I = 1; I <= Text.Length; I++)
            {
                //dcr = dcr + Strings.Chr((Strings.Asc(Strings.Mid(Text, I, 1))) - 100);
            }
            return dcr;
        }
    }
}
