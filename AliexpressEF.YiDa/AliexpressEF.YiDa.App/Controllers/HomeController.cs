using AliexpressEF.YiDa.Models;
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
            return View();
        }
    }
}
