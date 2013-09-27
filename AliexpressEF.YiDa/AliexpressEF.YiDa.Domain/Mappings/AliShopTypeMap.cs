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
    /// AliShopTypeMap
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
    public class AliShopTypeMap : BaseEntityMap<AliShopType>
    {
        public AliShopTypeMap()
        {
            Table("AliShops");

            Map(x => x.ShopTitle).Length(200);
            Map(x => x.RefreshToken).Length(200);
            Map(x => x.AccessToken).Length(200);
            Map(x => x.Manager).Length(200);
            Map(x => x.Phone).Length(200);
            Map(x => x.Status);
            Map(x => x.BeginOn);
            Map(x => x.EndOn);
            Map(x => x.CanNum);
            Map(x => x.RefershToken);
            Map(x => x.TokenUpdateOn);
            Map(x => x.ReturnName).Length(200);
            Map(x => x.ReturnAddress).Length(400);
            Map(x => x.BuyerMemo).Length(4000);
            Map(x => x.UId);
        }
    }
}
