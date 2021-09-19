using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class Profile : ComplexEntity
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }


        // navigation props:
        public virtual User User { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
