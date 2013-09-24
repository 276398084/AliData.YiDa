//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// PayRecordType
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
    public class PayRecordType : BaseEntity
    {


        /// <summary>
        /// 用户
        /// </summary>
        public virtual int Uid { get; set; }

        /// <summary>
        /// 店铺
        /// </summary>
        public virtual String Shop { get; set; }

        /// <summary>
        /// 用户支付宝
        /// </summary>
        public virtual String PayAccount { get; set; }

        /// <summary>
        /// 一个月
        ///一个季度
        ///半年
        ///一年
        /// </summary>
        public virtual int PayType { get; set; }

        /// <summary>
        /// 接收支付宝
        /// </summary>
        public virtual String RecipientAccount { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public virtual DateTime PayOn { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual double Amount { get; set; }

        /// <summary>
        /// Memo
        /// </summary>
        public virtual String Memo { get; set; }

    }
}
