using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interface;
using Model.MobileSale;

namespace DBoxSite.Controllers.MobileStat
{
    public class StatController : Controller
    {
        //
        // GET: /Stat/

        private IRocketDataService _RockDataService;
        public StatController(IRocketDataService rockDataService)
        {
            this._RockDataService = rockDataService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SyncData(int sid, int count = 1000)
        {
            Func<string> result = () => _RockDataService.GetSaleData(sid, count);

            return Content(result());
        }
    }
}
