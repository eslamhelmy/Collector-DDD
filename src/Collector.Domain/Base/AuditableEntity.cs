using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Domain.Base
{
    public abstract class AuditableEntity<T> : Entity
    {
            public int CreatedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public int ModifiedBy { get; set; }
            public DateTime ModifiedAt { get; set; }
    }
}
