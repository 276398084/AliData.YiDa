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
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        #region 用户页面菜单
        public class PageAuthorityTree : ExtTreeNode<PageAuthorityTree>
        {
            public string name { get; set; }
            public string code { get; set; }
            public string area { get; set; }
            public string controller { get; set; }
            public string action { get; set; }
            public int indexField { get; set; }
            public bool isDisable { get; set; }
            public bool isHide { get; set; }
            public string icon1 { get; set; }
            public string icon2 { get; set; }
            public string icon3 { get; set; }
            public string winId { get; set; }
        }
        [Description("返回当前用户的菜单权限")]

        public ActionResult GetPageMenuView()
        {
            var list = PageAuthority.GetTestList();

            var result = new List<PageAuthorityTree>();

            recursion(new PageAuthorityTree { id = 0, children = new List<PageAuthorityTree>() }, result, list);
            return JsonSerialization(result);
        }
        //递归
        private void recursion(PageAuthorityTree parentNode, IList<PageAuthorityTree> result, IList<PageAuthority> list)
        {
            foreach (var item in from c in list where c.Parent == parentNode.id select c)
            {
                var child = new PageAuthorityTree
                {
                    name = item.Text,
                    code = item.Code,
                    area = item.Area,
                    controller = item.Controller,
                    action = item.Action,
                    indexField = item.IndexField,
                    isDisable = item.IsDisable,
                    isHide = item.IsHide,
                    icon1 = item.IconCss16,
                    icon2 = item.IconCss24,
                    icon3 = item.IconCss48,
                    winId = item.PageId,

                    id = item.Id,
                    text = item.Text,
                    leaf = item.IsLeaf,
                    children = new List<PageAuthorityTree>(),
                    level = item.NodeLevel,
                    treeid = item.TreeIds
                };
                if (item.Parent == 0)
                {
                    result.Add(child);
                }
                else
                {
                    parentNode.children.Add(child);
                }
                recursion(child, result, list);
            }
        }
        #endregion

    }
}
