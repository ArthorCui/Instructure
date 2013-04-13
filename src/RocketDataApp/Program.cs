using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Service;

namespace RocketDataApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRocketDataService service = new RocketDataService();
            service.GetSaleData();

        }
    }
}
