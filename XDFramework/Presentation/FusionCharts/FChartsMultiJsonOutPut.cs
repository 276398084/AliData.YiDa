using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    public class FChartsMultiJsonOutPut<Tc, Td, Te>
        where Tc : FChartsModel
        where Td : FChartsData
        where Te : FChartsData
    {
        /// <summary>
        /// 报表对象基本属性
        /// </summary>
        public Tc chart { get; set; }
        /// <summary>
        /// 分类对象
        /// </summary>
        public Td[] categories { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public Te[] dataset { get; set; }
    }
}
