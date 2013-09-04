using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtDataModel
{
    public class ExtGrid<T>
    {
        public long total { get; set; }
        public IList<T> data { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string msg { get; set; }
    }
}
