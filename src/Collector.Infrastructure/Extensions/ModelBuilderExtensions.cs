using Collector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Infrastructure
{
        public static class ModelBuilderExtensions
        {
            public static void Seed(this ModelBuilder modelBuilder)
            {

                modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Password = "P@ssw0rd"
                    }
                );

        }
    }
}
