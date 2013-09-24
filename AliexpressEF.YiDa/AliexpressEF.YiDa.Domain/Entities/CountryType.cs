//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// CountryType
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
    public class CountryType:BaseEntity
    {
       

        /// <summary>
        /// CCountry
        /// </summary>
        public virtual String CCountry { get; set; }

        /// <summary>
        /// ECountry
        /// </summary>
        public virtual String ECountry { get; set; }

        /// <summary>
        /// CountryCode
        /// </summary>
        public virtual String CountryCode { get; set; }

    }
}
