using Microsoft.Extensions.DependencyInjection;
using Collector.Domain.Interfaces.Repositories;
using Collector.Domain.Interfaces.UnitOfWork;
using Collector.Infrastructure.Repositories;
using Collector.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Collector.API.Mediator;
using System.Reflection;
using Collector.Domain.Dispatcher;
using MediatR;
using Collector.Domain.Services;
using Collector.API.ExternalClients;

namespace Collector.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                  .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                  .AddScoped<ICovidHistoryRepository, CovidHistoryRepository>()
                  .AddScoped<ICovidSummaryRepository, CovidSummaryRepository>()
                  .AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return
                services.AddDbContext<CollectorContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DBConnection")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICovidHistoryService, CovidHistoryService>()
                .AddScoped<ICovidSummaryService, CovidSummaryService>()
                .AddScoped<IUserService, UserService>();
        }
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(MediatrDomainEventDispatcher).GetTypeInfo().Assembly);
        }
        public static IServiceCollection AddDispatcherServices(this IServiceCollection services)
        {
            return services.AddScoped<IDomainEventDispatcher, MediatrDomainEventDispatcher>();
        }

        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHttpClient<CovidClient>();
            return services.AddHostedService<CovidHostedService>();
        }

        
    }
}