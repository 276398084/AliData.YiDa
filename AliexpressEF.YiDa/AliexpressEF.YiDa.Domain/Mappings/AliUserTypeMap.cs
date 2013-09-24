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
    /// AliUserTypeMap
    /// 用户表
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
    public class AliUserTypeMap : BaseEntityMap<AliUserType> 
    {
        public AliUserTypeMap()
        {
            Table("AliUsers");
          
            Map(x => x.UserName).Length(200);
            Map(x => x.PassWord).Length(200);
            Map(x => x.RealName).Length(200);
            Map(x => x.Phone).Length(200);
            Map(x => x.Address).Length(200);
            Map(x => x.QQ).Length(200);
            Map(x => x.WW).Length(200);
            Map(x => x.Tel).Length(200);
            Map(x => x.Memo).Length(200);
            Map(x => x.Status);
            Map(x => x.Type);
            Map(x => x.BeginOn);
            Map(x => x.EndOn);
        }
    }
}
