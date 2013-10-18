using System;
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
    public class AliUserController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            // 注销登录
            return View("Login");

        }

        [HttpPost]
        public ActionResult Login(AliUserType user)
        {

            List<AliUserType> userlist = base.GetList<AliUserType>("UserName", user.UserName, " o.PassWord='" + user.PassWord + "'");
            if (userlist.Count > 0)
            {
                Session["aliUser"] = userlist[0];
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Username", "用户名或者密码出错。");
            return View();
        }

        [HttpPost]
        public JsonResult Create(AliUserType obj)
        {
            obj.Status = 1;
            obj.Type = 0;
            obj.EndOn = DateTime.Now.AddMonths(1);
            obj.BeginOn = DateTime.Now;
            base.Save<AliUserType>(obj);
            return Json(new { IsSuccess = true });
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            AliUserType obj = base.Get<AliUserType>(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(AliUserType obj)
        {
            base.Update<AliUserType>(obj);
            return Json(new { IsSuccess = true });
        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            base.Delete<AliUserType>(id);
            return Json(new { IsSuccess = true });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {
            long total = 0;
            IList<AliUserType> objList = base.PaggingList<AliUserType>(rows * (page - 1), rows, sort, search, out total);
            return Json(new { total = total, rows = objList });
        }
    }
}

