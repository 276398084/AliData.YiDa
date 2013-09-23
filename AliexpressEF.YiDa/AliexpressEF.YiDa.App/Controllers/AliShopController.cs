using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

using NHibernate;
using AliexpressEF.YiDa.Controllers;
using AliexpressEF.YiDa.Domain;
using XD.Framework.Repository;

namespace AliexpressEF.YiDa.Controllers
{
    public class AliShopController : BaseController
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
        public JsonResult Create(AliShopType obj)
        {
            base.Save<AliShopType>(obj);
            return Json(new { IsSuccess = true });
        }



        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            AliShopType obj = base.Get<AliShopType>(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(AliShopType obj)
        {

            base.Update<AliShopType>(obj);
            return Json(new { IsSuccess = "true" });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            base.Delete<AliShopType>(id);
            return Json(new { IsSuccess = "true" });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {

            long total = 0;
            IList<AliShopType> objList = base.PaggingList<AliShopType>(rows * (page - 1), rows, sort, search, out total);

            return Json(new { total = total, rows = objList });
        }

    }
}

