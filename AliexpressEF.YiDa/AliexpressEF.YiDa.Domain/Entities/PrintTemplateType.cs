//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// PrintTemplateType
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
    public class PrintTemplateType : BaseEntity
    {


        /// <summary>
        /// UID为0，就是公用模板
        /// </summary>
        public virtual int UId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public virtual String TempName { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public virtual String Content { get; set; }

    }
}
