using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    public class FChartsJsonOutPut<Tc, Td>
        where Tc : FChartsModel
        where Td : FChartsData
    {
        /// <summary>
        /// 报表对象
        /// </summary>
        public Tc chart { get; set; }
        /// <summary>
        /// 数据对象
        /// </summary>
        public Td[] data { get; set; }
    }
}
