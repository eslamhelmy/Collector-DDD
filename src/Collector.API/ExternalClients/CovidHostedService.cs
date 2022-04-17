using Collector.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Collector.Mappers.ViewModels;
using Collector.Domain.Interfaces.UnitOfWork;
using System;
using Microsoft.Extensions.DependencyInjection;
using Collector.Infrastructure;
using AutoMapper;
using Collector.Domain.Entities;

namespace Collector.API.ExternalClients
{
    public class CovidHostedService : IHostedService
    {
        private readonly CovidClient _covidClient;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        public CovidHostedService(CovidClient covidClient, IServiceProvider serviceProvider, IMapper mapper)
        {
            _covidClient = covidClient;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
         
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
           var data = await _covidClient.GetUAECovidHistoryAsync();
            var summary = await _covidClient.GetCovidSummaryAsync();
          
            using (var scope = _serviceProvider.CreateScope())
            {
                var covidHistoryRepository =
                    scope.ServiceProvider
                        .GetRequiredService<ICovidHistoryRepository>();

                var covidSummaryRepository =
                    scope.ServiceProvider
                        .GetRequiredService<ICovidSummaryRepository>();

                var collectorContext =
                    scope.ServiceProvider
                        .GetRequiredService<CollectorContext>();

                var unitOfWork =
                    scope.ServiceProvider
                        .GetRequiredService<IUnitOfWork>();
          
                var count = covidHistoryRepository.Count();
                if (count == 0)
                {
                    await covidHistoryRepository.AddRangeAsync(data.Select(x => _mapper.Map<CovidHistory>(x)));
                    await covidSummaryRepository.AddAsync(_mapper.Map<CovidSummary>(summary.Global));
                    await unitOfWork.SaveChangesAsync();
                }
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
