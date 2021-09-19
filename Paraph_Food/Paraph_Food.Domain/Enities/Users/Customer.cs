using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class Customer : ComplexEntity
    {
        public long UserId { get; set; }
        public long CashBalance { get; set; }
        public int Score { get; set; }

        // navigation props:
        public virtual User User { get; set; }
    }
}
