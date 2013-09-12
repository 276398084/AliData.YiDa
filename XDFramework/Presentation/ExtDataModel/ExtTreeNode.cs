using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtDataModel
{
    /// <summary>
    /// Ext树节点 数据结构
    /// <remarks>具体业务中如有需要应继承此类</remarks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExtTreeNode<T>
    {
        public int id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public bool leaf { get; set; }
        public virtual int level { get; set; }
        public virtual string treeid { get; set; }
        public virtual IList<T> children { get; set; }


    }
}
