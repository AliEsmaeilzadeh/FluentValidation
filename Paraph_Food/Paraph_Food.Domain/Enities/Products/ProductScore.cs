using Paraph_Food.Domain.Enities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Products
{
    public class ProductScore
    {
        public int ProductId { get; set; }
        public long UserId { get; set; }
        public double Score { get; set; }


        // navigation props:
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
