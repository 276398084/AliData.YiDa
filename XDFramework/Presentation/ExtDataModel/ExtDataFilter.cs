using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtDataModel
{
    /// <summary>
    /// 字段过滤器
    /// </summary>
    public class ExtDataFilter
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 比较规则
        /// </summary>
        public string comparison { get; set; }
    }
}
