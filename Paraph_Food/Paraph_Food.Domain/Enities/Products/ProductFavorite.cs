using Paraph_Food.Domain.Enities.BaseEntities;
using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Products
{
    public class ProductFavorite
    {
        public long UserId { get; set; }
        public int ProductId { get; set; }


        // navigation props:
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
