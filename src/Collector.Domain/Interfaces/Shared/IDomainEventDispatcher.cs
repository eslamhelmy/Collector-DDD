
using Collector.Domain.Base;
using System.Threading.Tasks;

namespace Collector.Domain.Dispatcher
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent @event);
    }
}
