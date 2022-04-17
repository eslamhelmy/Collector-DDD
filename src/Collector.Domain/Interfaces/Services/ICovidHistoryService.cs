using Collector.Domain.ViewModels;
using Collector.Mappers.ViewModels;
using System.Threading.Tasks;

namespace Collector.Domain.Services
{
    public interface ICovidHistoryService
    {
        Task<PagingViewModel<CovidHistoryViewModel>> GetCovidHistoryAsync(int pageIndex = 1, int pageSize = 10);
        Task<ResponseViewModel<int>> AddAsync(CovidHistoryCreateViewModel viewModel);
        Task<ResponseViewModel<bool>> UpdateAsync(CovidHistoryEditViewModel viewModel);
        Task<ResponseViewModel<bool>> DeleteAsync(int id);
    }
}
