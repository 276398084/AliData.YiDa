//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;
using XD.Framework.AbstractModel.Mapping;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// AliOrderProductTypeMap
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
    public class AliOrderProductTypeMap : BaseEntityMap<AliOrderProductType>
    {
        public AliOrderProductTypeMap()
        {
            Table("AliOrderProducts");

            Map(x => x.OId);
            Map(x => x.ItemId).Length(100);
            Map(x => x.SKU).Length(200);
            Map(x => x.Qty);
            Map(x => x.Title).Length(800);
            Map(x => x.Price);
            Map(x => x.ImgUrl).Length(400);
            Map(x => x.ItemUrl).Length(400);
        }
    }
}
