using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Interface;
using Model.Report;

namespace DBoxSite.Controllers.Report
{
    public class ReportUIController : Controller
    {
        private IReportUIService _reportUIService;
        public ReportUIController(IReportUIService ReportUIService)
        {
            this._reportUIService = ReportUIService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Report()
        {
            var issueList = new List<OTADataEntry>();



            return View();
        }

        public ActionResult SendReport()
        {

            return View();
        }

        [HttpGet]
        public ActionResult SetDefaultSetting(DateTime dateTime)
        {
            var receiverMailList = new List<MailEntry>() { };
            var senderMail = new MailEntry()
            {
                UserName = "Cuijiequan",
                Password = "1314dawn",
                NickName = "Arthor",
                Address = "cuijiequan@tydtech.com"
            };

            var statContent = "Hi All";

            return View();
        }

        [HttpPost]
        public ActionResult SetDefaultSetting()
        {


            return RedirectToAction("Report");
        }



    }
}
