using System;
using System.Collections.Generic;
using System.Text;

namespace Paraph_Food.Domain.Enities.BaseEntities
{
    public class SimpleEntityWithId<TKey> : SimpleEntity
    {
        public TKey Id { get; set; }
    }
}
