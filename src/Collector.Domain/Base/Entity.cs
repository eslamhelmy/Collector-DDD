using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Domain.Base
{
    public abstract class Entity : BaseEntity
    {
            public int Id { get; set; }
    }
}
