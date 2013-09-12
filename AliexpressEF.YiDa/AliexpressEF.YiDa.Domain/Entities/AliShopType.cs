//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// AliShopType
    /// 店铺表
    /// 
    /// 修改纪录
    /// 
    ///  版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date></date>
    /// </author>
    /// </summary>
    public class AliShopType : BaseEntity
    {
       

        /// <summary>
        /// 店铺名称
        /// </summary>
        public virtual String ShopTitle { get; set; }

        /// <summary>
        /// 更新Token
        /// </summary>
        public virtual String RefreshToken { get; set; }

        /// <summary>
        /// 账户Token
        /// </summary>
        public virtual String AccessToken { get; set; }

        /// <summary>
        /// 店铺负责人
        /// </summary>
        public virtual String Manager { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual String Phone { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime BeginOn { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime EndOn { get; set; }

        /// <summary>
        /// 可打印数量
        /// </summary>
        public virtual int CanNum { get; set; }

        /// <summary>
        /// Token更新时间
        /// </summary>
        public virtual DateTime TokenUpdateOn { get; set; }

        /// <summary>
        /// 回邮接收人
        /// </summary>
        public virtual String ReturnName { get; set; }

        /// <summary>
        /// 回邮地址
        /// </summary>
        public virtual String ReturnAddress { get; set; }

    }
}
