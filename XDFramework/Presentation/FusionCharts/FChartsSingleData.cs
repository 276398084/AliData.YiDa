using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    /// <summary>
    /// 简单报表数据对象
    /// </summary>
    public class FChartsSingleData<T> : FChartsData
    {
        /// <summary>
        /// 属性
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public T value { get; set; }
    }
}
