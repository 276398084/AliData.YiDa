using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AliexpressEF.YiDa.Domain;
//using KeWeiOMS.NhibernateHelper;
using NHibernate;
using AliexpressEF.YiDa.Domain;
using AliexpressEF.API;

namespace AliexpressEF.YiDa.Controllers
{
    public class AliShopController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult AddressEdit()
        {
            return View();
        }

        public ActionResult SellerMemoEdit()
        {
            return View();
        }

        public JsonResult Create(string code)
        {
            AliShop shop = AliUtil.GetRefreshToken(code);
            AliShopType obj = new AliShopType();
            obj.ShopTitle = shop.resource_owner;
            obj.RefershToken = DateTime.Now;
            obj.RefreshToken = shop.refresh_token;
            obj.AccessToken = shop.access_token;
            obj.Manager = shop.aliId;
            obj.BeginOn = DateTime.Now;
            obj.EndOn = DateTime.Now;
            obj.Status = 1;
            obj.TokenUpdateOn = DateTime.Now;
            base.Save<AliShopType>(obj);
            return Json(new { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult GetAuthUrl()
        {
            return Json(new { IsSuccess = true, Result = AliUtil.GetAuthUrl() });
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
            //AliShopType shop = base.Get<AliShopType>(obj.Id);
            // shop.ShopTitle
            // base.Update<AliShopType>(obj);
            return Json(new { IsSuccess = true });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            base.Delete<AliShopType>(id);
            return Json(new { IsSuccess = true });
        }

        public JsonResult GetALLBox()
        {
            List<object> result = new List<object>();
            IList<AliShopType> list = GetAll<AliShopType>();
            result.Add(new { id = 0, text = "全部" });
            foreach (AliShopType item in list)
            {
                result.Add(new { id = item.Id, text = item.ShopTitle });
            }
            return Json(result);
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {

            long total = 0;
            IList<AliShopType> objList = base.PaggingList<AliShopType>(rows * (page - 1), rows, sort, search, out total);

            return Json(new { total = total, rows = objList });
        }
    }
}

