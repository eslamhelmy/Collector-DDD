using AutoMapper;
using Collector.Domain.Entities;
using Collector.Domain.Interfaces.Repositories;
using Collector.Domain.Interfaces.UnitOfWork;
using Collector.Domain.Services;
using Collector.Domain.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Infrastructure.Services
{
    public class CovidHistoryService : ICovidHistoryService
    {
        private readonly ICovidHistoryRepository _covidHistoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CovidHistoryService(ICovidHistoryRepository covidHistoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _covidHistoryRepository = covidHistoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagingViewModel<CovidHistoryViewModel>> GetCovidHistoryAsync(int pageIndex = 1, int pageSize = 10)
        {
            var records = _covidHistoryRepository.Count();
            if (records <= pageSize || pageIndex <= 0)
            {
                pageIndex = 1;
            }

            int pages = (int)Math.Ceiling((double)records / pageSize);

            var data = (await _covidHistoryRepository.GetCovidHistory(pageIndex, pageSize))
                       .Select(x => _mapper.Map<CovidHistoryViewModel>(x)).ToList();

            return new PagingViewModel<CovidHistoryViewModel>
            {
                Pages = pages,
                Records = records,
                Result = data
            };
        }
        public async Task<ResponseViewModel<int>> AddAsync(CovidHistoryCreateViewModel viewModel)
        {
            var model = await _covidHistoryRepository.AddAsync(_mapper.Map<CovidHistory>(viewModel));
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseDto<int>
            {
                Data = model.Id
            };
        }

        public async Task<ResponseViewModel<bool>> UpdateAsync(CovidHistoryEditViewModel viewModel)
        {
            var existedModel = await _covidHistoryRepository.GetByIdAsync(viewModel.Id);
            if (existedModel == null)
            {
                return new FailureResponseDto<bool>
                {
                    Data = false
                };
            }
            await _covidHistoryRepository.UpdateAsync(_mapper.Map<CovidHistory>(viewModel));
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseDto<bool>
            {
                Data = true
            };
        }

        public async Task<ResponseViewModel<bool>> DeleteAsync(int id)
        {
            var existedModel = await _covidHistoryRepository.GetByIdAsync(id);
            if (existedModel == null)
            {
                return new FailureResponseDto<bool>
                {
                    Data = false
                };
            }

            await _covidHistoryRepository.DeleteAsync(existedModel);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResponseDto<bool>
            {
                Data = true
            };
        }

        
    }
}
