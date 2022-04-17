using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Domain.Base
{
    public class BaseEntity
    {
        [NotMapped]
        private List<BaseDomainEvent> _events;
        [NotMapped]
        public IReadOnlyList<BaseDomainEvent> Events => _events?.AsReadOnly();

        protected void AddEvent(BaseDomainEvent @event)
        {
            _events = _events ?? new List<BaseDomainEvent>();
            _events.Add(@event);
        }

        protected void RemoveEvent(BaseDomainEvent @event)
        {
            _events?.Remove(@event);
        }
    }
}
