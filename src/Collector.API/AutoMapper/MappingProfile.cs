using AutoMapper;
using Collector.Domain.Entities;
using Collector.Domain.ViewModels;
using Collector.Mappers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CovidHistoryCreateViewModel, CovidHistory>();
            CreateMap<CovidHistoryEditViewModel, CovidHistory>();
            CreateMap<CovidHistory, CovidHistoryViewModel>();
            CreateMap<CovidSummary, CovidSummaryViewModel>().ReverseMap();
        }
    }
}
