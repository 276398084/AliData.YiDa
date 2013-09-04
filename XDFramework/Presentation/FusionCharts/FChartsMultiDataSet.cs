using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    /// <summary>
    /// 复杂报表数据源集合对象
    /// </summary>
    public class FChartsMultiDataSet<Td> : FChartsData
        where Td : FChartsMultiData
    {
        public FChartsMultiDataSet()
        {
            ShowValues = "0";
        }
        /// <summary>
        /// 数列名称
        /// </summary>
        public string SeriesName { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 图形上是否显示值
        /// </summary>
        public string ShowValues { get; set; }
        /// <summary>
        /// 透明度
        /// </summary>
        public string Alpha { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public Td[] data { get; set; }
    }
}
