using Collector.Domain.Entities;
using Collector.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Collector.Infrastructure.Repositories
{
    public class CovidSummaryRepository : GenericRepository<CovidSummary>, ICovidSummaryRepository
    {
    
        public CovidSummaryRepository(CollectorContext dbContext) : base(dbContext)
        {
        }

        public async Task<CovidSummary> GetSummaryAsync()
        {
            return await FirstOrDefaultAsync();
        }

    }
}
