//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// AliOrderProductType
    /// 订单商品
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
    public class AliOrderProductType : BaseEntity
    {
       

        /// <summary>
        /// OId
        /// </summary>
        public virtual int OId { get; set; }

        /// <summary>
        /// ItemId
        /// </summary>
        public virtual String ItemId { get; set; }

        /// <summary>
        /// SKU
        /// </summary>
        public virtual String SKU { get; set; }

        /// <summary>
        /// Qty
        /// </summary>
        public virtual int Qty { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public virtual String Title { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public virtual double Price { get; set; }

        /// <summary>
        /// ImgUrl
        /// </summary>
        public virtual String ImgUrl { get; set; }

        /// <summary>
        /// ItemUrl
        /// </summary>
        public virtual String ItemUrl { get; set; }

    }
}
