using Collector.Domain.Entities;
using Collector.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Infrastructure.Repositories
{
    public class CovidHistoryRepository:GenericRepository<CovidHistory>, ICovidHistoryRepository
    {
    
        public CovidHistoryRepository(CollectorContext dbContext) : base(dbContext)
        {
        }

        public int Count()
        {
          return GetAll().Count();
        }

        public async Task<IEnumerable<CovidHistory>> GetCovidHistory(int pageIndex = 1, int pageSize = 10)
        {     
            var result = await GetPagedReponseAsync(pageIndex, pageSize);
            return result;                 
        }
    }
}
