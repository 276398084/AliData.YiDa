using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    public class FChartsPie3D : FChartsModel
    {
        /// <summary>
        /// 饼图参数
        /// </summary>
        public FChartsPie3D()
            : base()
        {
            PieSliceDepth = "30";
        }

        /// <summary>
        /// 你的大饼有多厚
        /// <remarks>默认30</remarks>
        /// </summary>
        public string PieSliceDepth { get; set; }

    }
}
