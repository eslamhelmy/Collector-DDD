using Collector.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collector.Domain.Interfaces.Repositories
{
    public interface ICovidSummaryRepository: IGenericRepository<CovidSummary>
    {
        public Task<CovidSummary> GetSummaryAsync();
    }
}
