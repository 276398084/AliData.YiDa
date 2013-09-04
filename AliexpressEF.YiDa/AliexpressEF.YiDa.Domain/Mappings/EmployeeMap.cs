using AliexpressEF.YiDa.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AliexpressEF.YiDa.Domain.Mappings
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Store);
        }
    }
}