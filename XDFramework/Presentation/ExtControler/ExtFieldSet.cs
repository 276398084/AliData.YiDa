using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.Presentation.ExtControler
{
    public class ExtFieldSet
    {
        public ExtFieldSet()
        {
            xtype = "OIT.ex.CreditFieldSet";
           // collapsible = true;
            //    defaults = new FieldSetDefaults { labelAlign = "right", labelWidth = 100, width = 280 };
            // layout = new FieldSetLayout { columns = 1, type = "table" };
        }
        public string xtype { get; private set; }

        public string title { get; set; }

        public bool collapsible { get; set; }

        public FieldSetDefaults defaults { get; set; }

        public FieldSetLayout layout { get; set; }

        public int count { get; set; }

        public string tableId { get; set; }

        #region class
        public class FieldSetDefaults
        {
            public string labelAlign { get; set; }

            public int labelWidth { get; set; }

            public int width { get; set; }
        }

        public class FieldSetLayout
        {
            public string type { get; set; }

            public int columns { get; set; }
        }
        #endregion

    }
}
