using Collector.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collector.Domain.Interfaces.Repositories
{
    public interface ICovidHistoryRepository: IGenericRepository<CovidHistory> 
    {
        public int Count();
        public Task<IEnumerable<CovidHistory>> GetCovidHistory(int pageIndex = 1, int pageSize = 10);
        
    }
}
