using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DManageSite.Models.Service.Interface
{
    public interface IStatService
    {
        string GetSaleData(int sid, int count);
    }
}
