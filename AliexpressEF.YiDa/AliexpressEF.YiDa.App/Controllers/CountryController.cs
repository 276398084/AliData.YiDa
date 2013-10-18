﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AliexpressEF.YiDa.Domain;
//using KeWeiOMS.NhibernateHelper;
using NHibernate;

namespace AliexpressEF.YiDa.Controllers
{
    public class CountryController : BaseController
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
        public JsonResult Create(CountryType obj)
        {
            base.Save<CountryType>(obj);
            return Json(new { IsSuccess = true });
        }



        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            CountryType obj = base.Get<CountryType>(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(CountryType obj)
        {

            base.Update<CountryType>(obj);
            return Json(new { IsSuccess = true });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            base.Delete<CountryType>(id);
            return Json(new { IsSuccess = true });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {

            long total = 0;
            IList<CountryType> objList = base.PaggingList<CountryType>(rows * (page - 1), rows, sort, search, out total);

            return Json(new { total = total, rows = objList });
        }
    }
}
