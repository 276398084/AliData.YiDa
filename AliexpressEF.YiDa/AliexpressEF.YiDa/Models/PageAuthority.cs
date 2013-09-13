using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Models
{

    /// <summary>
    /// 页面权限
    /// </summary>
    public class PageAuthority : TreeNode
    {
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// Area
        /// </summary>
        public virtual string Area { get; set; }
        /// <summary>
        /// Controller
        /// </summary>
        public virtual string Controller { get; set; }
        /// <summary>
        /// Action
        /// </summary>
        public virtual string Action { get; set; }
        /// <summary>
        /// 图标16
        /// </summary>
        public virtual string IconCss16 { get; set; }
        /// <summary>
        /// 图标24
        /// </summary>
        public virtual string IconCss24 { get; set; }
        /// <summary>
        /// 图标48
        /// </summary>
        public virtual string IconCss48 { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int IndexField { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public virtual bool IsHide { get; set; }
        /// <summary>
        /// 模块Id
        /// </summary>
        public virtual string PageId { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public virtual bool IsDisable { get; set; }

        ///// <summary>
        ///// 包含的Role
        ///// </summary>
        //public virtual ISet<SysRole> Roles { get; set; }

        public static IList<PageAuthority> GetTestList()
        {
            var list = new List<PageAuthority>();
            list.Add(new PageAuthority { Id = 1, Parent = 0, Text = "业务管理", IconCss16 = "系统数据维护16", IconCss24 = "", IconCss48 = "", PageId = "0", IsLeaf = false, NodeLevel = 1 });
            list.Add(new PageAuthority { Id = 2, Parent = 1, Text = "订单列表", IconCss16 = "databasel16", IconCss24 = "databasel24", IconCss48 = "databasel48", PageId = "/Order/OrderList", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 3, Parent = 1, Text = "订单同步", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/Order/Index", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 4, Parent = 1, Text = "国家列表", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/TestModule/Module2/Module2", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 5, Parent = 1, Text = "打印模板", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/TestModule/Module2/Module2", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 6, Parent = 1, Text = "用户管理", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/TestModule/Module2/Module2", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 7, Parent = 1, Text = "店铺管理", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/TestModule/Module2/Module2", IsLeaf = true, NodeLevel = 2 });
            list.Add(new PageAuthority { Id = 8, Parent = 1, Text = "打印模板", IconCss16 = "role16", IconCss24 = "role24", IconCss48 = "role48", PageId = "/TestModule/Module2/Module2", IsLeaf = true, NodeLevel = 2 });

            //list.Add(new PageAuthority { Id = 4, Parent = 0, Text = "一级菜单测试二", IconCss16 = "filter16", IconCss24 = "", IconCss48 = "", PageId = "0", IsLeaf = false, NodeLevel = 1 });
            return list;
        }

    }

}