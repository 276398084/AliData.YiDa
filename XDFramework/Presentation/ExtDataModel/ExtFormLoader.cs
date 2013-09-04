using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtDataModel
{
    /// <summary>
    /// Ext表单自动加载数据的数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExtFormLoader<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
    }
}
