using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageHandleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ImageHandleService service = new ImageHandleService();
            service.Handle();
        }
    }
}
