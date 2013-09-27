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
    /// AliOrderTypeMap
    /// 订单表
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
    public class AliOrderTypeMap : BaseEntityMap<AliOrderType>
    {
        public AliOrderTypeMap()
        {
            Table("AliOrders");

            Map(x => x.OrderNo).Length(200);
            Map(x => x.Status).Length(200);
            Map(x => x.HasPrint);
            Map(x => x.HasMerger);
            Map(x => x.BuyerName).Length(200);
            Map(x => x.BuyerEmail).Length(400);
            Map(x => x.CurrencyCode).Length(20);
            Map(x => x.Amount);
            Map(x => x.LogisticType).Length(50);
            Map(x => x.ExtTrackCode);
            Map(x => x.TrackCode).Length(50);
            Map(x => x.GenerateOn);
            Map(x => x.SendOn);
            Map(x => x.RecipientName).Length(200);
            Map(x => x.RecipientStreet).Length(400);
            Map(x => x.RecipientCity).Length(200);
            Map(x => x.RecipientProvince).Length(200);
            Map(x => x.RecipientCountry).Length(200);
            Map(x => x.CountryCode).Length(200);
            Map(x => x.RecipientPhone).Length(200);
            Map(x => x.RecipientTel).Length(200);
            Map(x => x.RecipientPostCode).Length(200);
            Map(x => x.OrderNote).Length(2000);
            Map(x => x.ShopId);
            Map(x => x.UId);
            Map(x => x.ShopTitle);
        }
    }
}
