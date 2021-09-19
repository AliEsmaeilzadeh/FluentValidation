using System;

namespace Paraph_Food.Domain.Enities.BaseEntities
{
    public class ComplexEntity : SimpleEntity
    {
        public DateTime CreatedDateTime { get; set; }
        public long CreatedUserId { get; set; }

        public DateTime? LastModifiedDateTime { get; set; }
        public long? LastModifiedUserId { get; set; }
    }
}
