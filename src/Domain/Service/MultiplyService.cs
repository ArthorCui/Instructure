using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class MultiplyService
    {
        public void NineNineMul()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    if (i >= j)
                    {
                        Console.WriteLine(j + "*" + i + "=" + j * i + " ");
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}