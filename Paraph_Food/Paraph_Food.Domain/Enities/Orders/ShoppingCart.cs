using Paraph_Food.Domain.Enities.BaseEntities;
using Paraph_Food.Domain.Enities.Products;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Orders
{
    public class ShoppingCart : SimpleEntity
    {
        public long CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public long Price { get; set; }
        public long DiscountAmount { get; set; }
        public DateTime DateTime { get; set; }


        // navigation props:
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
