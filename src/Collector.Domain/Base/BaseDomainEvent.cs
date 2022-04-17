using System;

namespace Collector.Domain.Base
{
    public class BaseDomainEvent
    {
        public BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }

        public Guid EventId { get; init; }
        public DateTime CreatedOn { get; init; }
    }
}
