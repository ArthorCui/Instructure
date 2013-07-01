using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdateAppTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            UpdateAppService svc = new UpdateAppService();
            svc.RebuilAppIndex();
        }
    }
}
