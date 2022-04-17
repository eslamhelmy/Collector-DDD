using AutoMapper;
using Collector.Domain.Interfaces.Repositories;
using Collector.Domain.Interfaces.UnitOfWork;
using Collector.Domain.Services;
using Collector.Domain.ViewModels;
using System.Threading.Tasks;

namespace Collector.Infrastructure.Services
{
    public class CovidSummaryService : ICovidSummaryService
    {
        private readonly ICovidSummaryRepository _covidSummaryRepository;
        private readonly IMapper _mapper;
        public CovidSummaryService(ICovidSummaryRepository covidSummaryRepository, IMapper mapper)
        {
            _covidSummaryRepository = covidSummaryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseViewModel<CovidSummaryViewModel>> GetSummaryAsync()
        {
            var summary = _mapper.Map<CovidSummaryViewModel>((await _covidSummaryRepository.GetSummaryAsync()));
            if(summary == null)
            {
                return new FailureResponseDto<CovidSummaryViewModel>
                {
                    Data = null
                };
            }
            return new SuccessResponseDto<CovidSummaryViewModel>
            {
                Data = summary
            };
        }
        
    }
}
