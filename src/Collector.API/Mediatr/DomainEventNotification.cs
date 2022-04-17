
using Collector.Domain.Base;
using MediatR;

namespace Collector.API.Mediatr
{
    public class DomainEventNotification<T> : INotification where T : BaseDomainEvent
    {
        public T DomainEvent { get; }

        public DomainEventNotification(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
