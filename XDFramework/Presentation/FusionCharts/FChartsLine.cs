using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    public class FChartsLine : FChartsModel
    {
        /// <summary>
        /// 折线图的参数
        /// </summary>
        public FChartsLine()
            : base()
        {
        }
        /// <summary>
        /// 折线的厚度
        /// </summary>
        public string LineThickness { get; set; }
        /// <summary>
        /// 折线节点半径，数字
        /// </summary>
        public string AnchorRadius { get; set; }
        /// <summary>
        ///  折线节点透明度，[0-100]
        /// </summary>
        public string AnchorBgAlpha { get; set; }
        /// <summary>
        /// 折线节点填充颜色，6位16进制颜色值
        /// </summary>
        public string AnchorBgColor { get; set; }
        /// <summary>
        /// 折线节点边框颜色，6位16进制颜色值
        /// </summary>
        public string AnchorBorderColor { get; set; }
        
    }
}
