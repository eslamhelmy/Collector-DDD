using Collector.Domain.Interfaces.UnitOfWork;
using System.Threading.Tasks;

namespace Collector.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CollectorContext _collectorContext;

        public UnitOfWork(CollectorContext collectorContext)
        {
            _collectorContext = collectorContext;
        }

        public Task<int> SaveChangesAsync()
        {
            return _collectorContext.SaveChangesAsync();
        }
    }
}
