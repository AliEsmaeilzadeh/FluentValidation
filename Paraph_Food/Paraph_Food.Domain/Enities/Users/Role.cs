using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class Role : ComplexEntityWithId<long>
    {
        public string Name { get; set; }


        // navigation props:
        public virtual ICollection<UserRole> Users { get; set; }
    }
}
