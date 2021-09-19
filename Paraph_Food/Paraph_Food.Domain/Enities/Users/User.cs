using Paraph_Food.Domain.Enities.BaseEntities;
using Paraph_Food.Domain.Enities.Products;
using System;
using System.Collections.Generic;
using System.Text;
using static Paraph_Food.Domain.Enums.Enums;

namespace Paraph_Food.Domain.Enities.Users
{
    public class User : ComplexEntityWithId<long>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserStatus UserStatus { get; set; }

        // navigation props:
        public virtual Profile Profile { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<UserRole> Roles { get; set; }
        public virtual ICollection<ProductFavorite> ProductFavorites { get; set; }
        public virtual ICollection<ProductScore> ProductScores { get; set; }
    }
}


