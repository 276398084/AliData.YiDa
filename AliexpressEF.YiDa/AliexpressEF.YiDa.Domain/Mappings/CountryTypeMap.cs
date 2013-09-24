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
    /// CountryTypeMap
    /// 国家表
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
    public class CountryTypeMap : BaseEntityMap<CountryType> 
    {
        public CountryTypeMap()
        {
            Table("Countrys");
            
            Map(x => x.CCountry).Length(100);
            Map(x => x.ECountry).Length(100);
            Map(x => x.CountryCode).Length(100);
        }
    }
}
