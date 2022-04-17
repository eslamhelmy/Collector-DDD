using Collector.Domain.Base;
using Collector.Domain.Dispatcher;
using Collector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collector.Infrastructure
{
    public partial class CollectorContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        public CollectorContext(DbContextOptions<CollectorContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CovidHistory> CovidHistories { get; set; }
        public virtual DbSet<CovidSummary> CovidSummaries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEntities = ChangeTracker.Entries<BaseEntity>();
            foreach (var domainEntity in domainEntities)
            {
                var events = domainEntity.Entity.Events;
                if (events != null)
                {
                    foreach (var item in events)
                    {
                        await _dispatcher.Dispatch(item);
                    }

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }




}
