using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtControler
{
    /// <summary>
    /// ext表单字段
    /// </summary>
    public class ExtField
    {
        public string xtype { get; set; }

        public string fieldLabel { get; set; }

        public int width { get; set; }

        public bool allowBlank { get; set; }

        public string name { get; set; }

        public int colspan { get; set; }

        public string dicCode { get; set; }

        public bool readOnly { get; set; }

        public string format { get; set; }
    }

    public class FieldDef
    {
        public string fName { get; set; }

        public string fValue { get; set; }

        public string fType { get; set; }
    }
}
