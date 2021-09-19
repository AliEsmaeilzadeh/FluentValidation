using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class UserRole : SimpleEntity
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }

        //navigation props:
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
