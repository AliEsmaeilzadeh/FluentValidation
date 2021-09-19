using NetTopologySuite.Geometries;
using Paraph_Food.Domain.Enities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.Users
{
    public class Address : SimpleEntityWithId<int>
    {
        public long ProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Point Location { get; set; }
        public bool IsDefault { get; set; }

        // navigation props:
        public virtual Profile Profile { get; set; }

    }
}
