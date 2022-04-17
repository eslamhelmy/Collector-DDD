using Collector.API.Mediatr;
using Collector.Domain.Base;
using Collector.Domain.Dispatcher;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Collector.API.Mediator
{
    public class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MediatrDomainEventDispatcher> _log;
        public MediatrDomainEventDispatcher(IMediator mediator, ILogger<MediatrDomainEventDispatcher> log)
        {
            _mediator = mediator;
            _log = log;
        }

        public async Task Dispatch(BaseDomainEvent @event)
        {
            var domainEventNotification = _createDomainEventNotification(@event);
            _log.LogDebug("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", @event.GetType());
            await _mediator.Publish(domainEventNotification);
        }

        private INotification _createDomainEventNotification(BaseDomainEvent domainEvent)
        {
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcherType, domainEvent);

        }
    }

}
