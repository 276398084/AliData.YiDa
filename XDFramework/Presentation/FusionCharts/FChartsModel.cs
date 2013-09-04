using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.FusionCharts
{
    /// <summary>
    /// FusionCharts的基类
    /// </summary>
    public abstract class FChartsModel
    {
        public FChartsModel()
        {
            ShowBorder = "0";
            Animation = "1";
            ShowAboutMenuItem = "0";
            ShowLabels = "1";
            ShowValues = "1";
            ShowLegend = "1";
            BaseFont = "宋体";
            BaseFontSize = "12";
            FormatNumberScale = "0";
        }

        #region 功能特性
        /// <summary>
        /// 是否显示FusionCharts公司的关于信息
        /// <remarks>默认0</remarks>
        /// </summary>
        public string ShowAboutMenuItem { get; set; }
        /// <summary>
        /// 是否显示边框
        /// <remarks>默认0</remarks>
        /// </summary>
        public string ShowBorder { get; set; }

        /// <summary>
        /// 开始出来的时候是否显示动画效果
        /// <remarks>默认1</remarks>
        /// </summary>
        public string Animation { get; set; }

        /// <summary>
        /// 是否显示属性名称
        /// <remarks>默认1</remarks>
        /// </summary>
        public string ShowLabels { get; set; }

        /// <summary>
        /// 是否显示值
        /// <remarks>默认1</remarks>
        /// </summary>
        public string ShowValues { get; set; }
        /// <summary>
        /// 属性名称间隔 默认为0
        /// </summary>
        public string LabelStep { get; set; }

        #endregion

        #region 图表和画布的样式
        /// <summary>
        /// 图表背景色，6位16进制颜色值
        /// </summary>
        public string BgColor { get; set; }
        /// <summary>
        /// 画布背景色，6位16进制颜色值
        /// </summary>
        public string CanvasBgColor { get; set; }
        /// <summary>
        /// 画布透明度，[0-100]
        /// </summary>
        public string CanvasBgAlpha { get; set; }
        /// <summary>
        /// 画布边框颜色，6位16进制颜色值
        /// </summary>
        public string CanvasBorderColor { get; set; }
        /// <summary>
        /// 画布边框厚度，[0-100]
        /// </summary>
        public string CanvasBorderThickness { get; set; }
        /// <summary>
        /// 投影透明度，[0-100]
        /// </summary>
        public string ShadowAlpha { get; set; }
        /// <summary>
        /// 是否显示图例
        /// <remarks>默认0</remarks>
        /// </summary>
        public string ShowLegend { get; set; }
        /// <summary>
        /// 调色板，指定颜色数量以便显示图例方便选取图表
        /// </summary>
        public string Palette { get; set; }

        #endregion

        #region 图表标题和轴名称
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        ///附标题 
        /// </summary>
        public string SubCaption { get; set; }
        /// <summary>
        /// 横向坐标轴(x轴)名称
        /// </summary>
        public string xAxisName { get; set; }
        /// <summary>
        /// 纵向坐标轴(y轴)名称
        /// </summary>
        public string yAxisName { get; set; }
        #endregion

        #region 字体属性
        /// <summary>
        /// 字体
        /// <remarks>默认宋体</remarks>
        /// </summary>
        public string BaseFont { get; set; }
        /// <summary>
        /// 字体大小
        /// <remarks>默认12</remarks>
        /// </summary>
        public string BaseFontSize { get; set; }
        /// <summary>
        /// 字体颜色
        /// <remarks></remarks>
        /// </summary>
        public string BaseFontColor { get; set; }
        /// <summary>
        /// 图表画布以外的字体样式
        /// </summary>
        public string OutCnvBaseFont { get; set; }
        /// <summary>
        /// 图表画布以外的字体大小
        /// </summary>
        public string OutCnvBaseFontSize { get; set; }
        /// <summary>
        /// 图表画布以外的字体颜色，6位16进制颜色值
        /// </summary>
        public string OutCnvBaseFontColor { get; set; }
        #endregion

        #region 数字格式
        /// <summary>
        /// 增加数字前缀
        /// </summary>
        public string NumberPrefix { get; set; }
        /// <summary>
        ///  增加数字后缀    % 为 '%25'
        /// </summary>
        public string NumberSuffix { get; set; }
        /// <summary>
        /// 是否格式化数字,默认为1(True),自动的给你的数字加上K（千）或M（百万）；若取0,则不加K或M
        /// </summary>
        public string FormatNumberScale { get; set; }
        /// <summary>
        /// 指定小数位的位数，[0-10]    例如：='0' 取整
        /// </summary>
        public string DecimalPrecision { get; set; }
        /// <summary>
        /// 指定水平分区线的值小数位的位数，[0-10]
        /// </summary>
        public string DivLineDecimalPrecision { get; set; }
        /// <summary>
        /// 指定y轴最大、最小值的小数位的位数，[0-10]
        /// </summary>
        public string LimitsDecimalPrecision { get; set; }
        /// <summary>
        /// 逗号来分隔数字(千位，百万位),默认为1(True)；若取0,则不加分隔符
        /// </summary>
        public string FormatNumber { get; set; }
        /// <summary>
        /// 指定小数分隔符,默认为'.'
        /// </summary>
        public string DecimalSeparator { get; set; }
        /// <summary>
        /// 指定千分位分隔符,默认为','
        /// </summary>
        public string ThousandSeparator { get; set; }
        #endregion

        #region Tool-tip/Hover标题
        /// <summary>
        /// 是否显示悬停说明框，默认为1(True)
        /// </summary>
        public string Showhovercap { get; set; }
        /// <summary>
        /// 悬停说明框背景色，6位16进制颜色值
        /// </summary>
        public string HoverCapBgColor { get; set; }
        /// <summary>
        /// 悬停说明框边框颜色，6位16进制颜色值
        /// </summary>
        public string HoverCapBorderColor { get; set; }
        /// <summary>
        /// 指定悬停说明框内值与值之间分隔符,默认为','
        /// </summary>
        public string HoverCapSepChar { get; set; }
        #endregion
    }
}
