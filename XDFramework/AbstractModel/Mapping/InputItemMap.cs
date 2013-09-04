using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XD.Framework.AbstractModel.Mapping
{
    public abstract class InputItemMap<T> : BaseEntityMap<T> where T : InputItem
    {
        public InputItemMap()
        {
            Map(t => t.Code, "CODE");
            Map(t => t.IndexField, "INDEX_FIELD");
            Map(t => t.InputCode, "INPUT_CODE");
            Map(t => t.PY, "PY");
            Map(t => t.Text, "`TEXT`");
            Map(t => t.WB, "WB");
            Map(t => t.Description, "`DESCRIPTION`");
        }
    }
}
