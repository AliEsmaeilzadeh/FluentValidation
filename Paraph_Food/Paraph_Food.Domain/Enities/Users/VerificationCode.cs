using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class VerificationCode : SimpleEntityWithId<int>
    {
        public string UserName { get; set; }
        public string Code { get; set; }
        public DateTime GenerateDateTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }

    }
}