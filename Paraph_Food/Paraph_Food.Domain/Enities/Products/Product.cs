using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Domain.Enities.Products
{
    public class Product : ComplexEntityWithId<int>
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
        public double DiscountValue { get; set; }
        public DiscountValueType DiscountValueType { get; set; }
        public bool IsAvailable { get; set; }


        // navigation props:
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductFavorite> Favorites { get; set; }
        public virtual ICollection<ProductScore> Scores { get; set; }
    }
}
