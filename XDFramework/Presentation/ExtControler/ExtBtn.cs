using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtControler
{
    public class ExtBtn
    {
        public ExtBtn()
        {
            xtype = "button";
        }
        public virtual string id { get; set; }
        public virtual string xtype { get; private set; }

        public virtual int margin { get; set; }

        public virtual string toggleGroup { get; set; }

        public virtual bool enableToggle { get; set; }

        public virtual string scale { get; set; }

        public virtual string text { get; set; }

        public virtual int width { get; set; }

        public virtual string tooltip { get; set; }

        public virtual string icon { get; set; }
    }
}
