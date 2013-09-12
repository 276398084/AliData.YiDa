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
    /// PayRecordTypeMap
    /// 付款记录表
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
    public class PayRecordTypeMap : BaseEntityMap<PayRecordType> 
    {
        public PayRecordTypeMap()
        {
            Table("PayRecord");
          
            Map(x => x.Uid);
            Map(x => x.Shop).Length(200);
            Map(x => x.PayAccount).Length(200);
            Map(x => x.PayType);
            Map(x => x.RecipientAccount).Length(200);
            Map(x => x.PayOn);
            Map(x => x.Amount);
            Map(x => x.Memo).Length(2000);
        }
    }
}
