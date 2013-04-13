using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBoxSite.Controllers.iTunesApp
{
    public class RssController : Controller
    {
        //
        // GET: /Rss/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return Content("");
        }

    }
}
