
using AliexpressEF.YiDa.App.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XD.Framework.Presentation.ExtDataModel;

namespace AliexpressEF.YiDa.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(MenuItem.GetMenu());
        }

        public ActionResult PrintData()
        {
            return View();
        }

        public ActionResult Nav()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult PrintSetup()
        {
            return View();
        }

        public ActionResult PrintDetail()
        {
            return View();
        }

        public ActionResult PrintDesign()
        {
            return View();
        }

    }
}
