//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// AliOrderType
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
    public class AliOrderType:BaseEntity
    {
        

        /// <summary>
        /// OrderNo
        /// </summary>
        public virtual String OrderNo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 是否打印
        /// </summary>
        public virtual int HasPrint { get; set; }

        /// <summary>
        /// 是否合并
        /// </summary>
        public virtual int HasMerger { get; set; }

        /// <summary>
        /// 买家ID
        /// </summary>
        public virtual String BuyerName { get; set; }

        /// <summary>
        /// 买家邮箱
        /// </summary>
        public virtual String BuyerEmail { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        public virtual String CurrencyCode { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public virtual double Amount { get; set; }

        /// <summary>
        /// 发货方式
        /// </summary>
        public virtual String LogisticType { get; set; }

        /// <summary>
        /// 预定挂号条码
        /// </summary>
        public virtual String ExtTrackCode { get; set; }

        /// <summary>
        /// 挂号条码
        /// </summary>
        public virtual String TrackCode { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public virtual DateTime GenerateOn { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public virtual DateTime SendOn { get; set; }

        /// <summary>
        /// 收件人名称
        /// </summary>
        public virtual String RecipientName { get; set; }

        /// <summary>
        /// 收件人街道
        /// </summary>
        public virtual String RecipientStreet { get; set; }

        /// <summary>
        /// 收件人城市
        /// </summary>
        public virtual String RecipientCity { get; set; }

        /// <summary>
        /// 收件人省
        /// </summary>
        public virtual String RecipientProvince { get; set; }

        /// <summary>
        /// 收件人国家
        /// </summary>
        public virtual String RecipientCountry { get; set; }

        /// <summary>
        /// 国家代码
        /// </summary>
        public virtual String CountryCode { get; set; }

        /// <summary>
        /// 收件人手机
        /// </summary>
        public virtual String RecipientPhone { get; set; }

        /// <summary>
        /// 收件人电话
        /// </summary>
        public virtual String RecipientTel { get; set; }

        /// <summary>
        /// 收件人邮编
        /// </summary>
        public virtual String RecipientPostCode { get; set; }

        /// <summary>
        /// 收件备注
        /// </summary>
        public virtual String OrderNote { get; set; }

        /// <summary>
        /// 账户/店铺
        /// </summary>
        public virtual int ShopId { get; set; }

        /// <summary>
        /// 卖家备注
        /// </summary>
        public virtual String SellNote { get; set; }

    }
}
