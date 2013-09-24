//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using XD.Framework.AbstractModel;

namespace AliexpressEF.YiDa.Domain
{

    /// <summary>
    /// AliUserType
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
    public class AliUserType:BaseEntity
    {


        /// <summary>
        /// 用户名
        /// </summary>
        public virtual String UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public virtual String PassWord { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public virtual String RealName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public virtual String Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public virtual String QQ { get; set; }

        /// <summary>
        /// WW
        /// </summary>
        public virtual String WW { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual String Tel { get; set; }

        /// <summary>
        /// Memo
        /// </summary>
        public virtual String Memo { get; set; }

        /// <summary>
        /// 1:正常
        ///0:停用
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 等级
        ///0.试用版客户
        ///1.专业版
        ///2.高级版
        ///3.企业版
        /// </summary>
        public virtual int Type { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime BeginOn { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime EndOn { get; set; }

    }
}
