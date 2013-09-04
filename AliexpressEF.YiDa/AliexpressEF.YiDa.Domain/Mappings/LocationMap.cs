using AliexpressEF.YiDa.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AliexpressEF.YiDa.Domain.Mappings
{
    public class LocationMap : ComponentMap<Location>
    {
        public LocationMap()
        {
            Map(x => x.Aisle);
            Map(x => x.Shelf);
        }
    }
}