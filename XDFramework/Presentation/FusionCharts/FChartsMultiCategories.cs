using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    /// <summary>
    /// 复杂报表类型集合对象
    /// </summary>
    public class FChartsMultiCategories<Td> : FChartsData
        where Td : FChartsMultiCategory
    {
        public FChartsMultiCategories()
        {
        }
        /// <summary>
        /// 类型对象
        /// </summary>
        public Td[] category { get; set; }
    }
}
