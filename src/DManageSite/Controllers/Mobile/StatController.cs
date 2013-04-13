using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DManageSite.Models.Service;

namespace DManageSite.Controllers.Mobile
{
    public class StatController : Controller
    {
        //
        // GET: /Stat/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SyncData(int sid, int count = 1000)
        {
            Response.ContentEncoding = Encoding.UTF8;
            StatService statService = new StatService();
            Func<string> result = () => statService.GetSaleData(sid, count);
            return Content(result());
        }

    }
}
