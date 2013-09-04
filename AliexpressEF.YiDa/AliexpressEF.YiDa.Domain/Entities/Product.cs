using System.Collections.Generic;

namespace AliexpressEF.YiDa.Domain.Entities
{
    public class Product
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual Location Location { get; set; }
        public virtual IList<Store> StoresStockedIn { get; set; }

        public Product()
        {
            StoresStockedIn = new List<Store>();
        }
    }

    public class Location
    {
        public virtual int Aisle { get; set; }
        public virtual int Shelf { get; set; }
    }
}