using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace XD.Framework.AbstractModel.Mapping
{
    public abstract class BaseEntityMap<T> : ClassMap<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {
            Version(t => t.Version);
            Map(t => t.CreateTime, "CREATE_TIME");
            DynamicInsert();
            DynamicUpdate();
        }
    }
}
