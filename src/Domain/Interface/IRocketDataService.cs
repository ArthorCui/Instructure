using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRocketDataService
    {
        string GetSaleData(int startId, int count);
        void GetSaleData();
    }
}
