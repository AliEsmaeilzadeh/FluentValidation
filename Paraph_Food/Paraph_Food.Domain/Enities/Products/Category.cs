using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Products
{
    public class Category : ComplexEntityWithId<int>
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public long PackingCost { get; set; }
        public int Order { get; set; }


        // navigation props:
        public virtual ICollection<Product> Products { get; set; }
    }
}