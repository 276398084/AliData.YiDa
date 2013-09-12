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
    /// PrintTemplateTypeMap
    /// 打印模板
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
    public class PrintTemplateTypeMap : BaseEntityMap<PrintTemplateType>
    {
        public PrintTemplateTypeMap()
        {
            Table("PrintTemplate");
            Map(x => x.UId);
            Map(x => x.TempName).Length(40);
            Map(x => x.Content);
        }
    }
}
