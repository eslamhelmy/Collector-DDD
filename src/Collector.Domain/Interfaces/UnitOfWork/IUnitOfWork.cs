using System.Threading.Tasks;

namespace Collector.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
