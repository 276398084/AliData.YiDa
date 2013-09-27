using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using NHibernate;
using AliexpressEF.YiDa.Controllers;
using AliexpressEF.YiDa.Domain;

namespace AliexpressEF.YiDa.Controllers
{
    public class PrintTemplateController : BaseController
    {



        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(PrintTemplateType obj)
        {
            base.Save<PrintTemplateType>(obj);
            return Json(new { IsSuccess = true });
        }



        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            PrintTemplateType obj = base.Get<PrintTemplateType>(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(PrintTemplateType obj)
        {

            base.Update<PrintTemplateType>(obj);
            return Json(new { IsSuccess = "true" });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            base.Delete<PrintTemplateType>(id);
            return Json(new { IsSuccess = "true" });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {

            long total = 0;
            IList<PrintTemplateType> objList = base.PaggingList<PrintTemplateType>(rows * (page - 1), rows, sort, search, out total);

            return Json(new { total = total, rows = objList });
        }
    }
}

