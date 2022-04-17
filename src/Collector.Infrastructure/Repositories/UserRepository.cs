using Collector.Domain.Entities;
using Collector.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Collector.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
    
        public UserRepository(CollectorContext dbContext) : base(dbContext)
        {
        }

      
        public async Task<User> GetUser(string username, string password)
        {     
            var result = (await GetAllAsync(x=> x.UserName == username && x.Password == password)).FirstOrDefault();
            return result;                 
        }
    }
}
