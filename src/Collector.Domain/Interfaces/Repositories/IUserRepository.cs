using Collector.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collector.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> GetUser(string username, string password);
    }
}
