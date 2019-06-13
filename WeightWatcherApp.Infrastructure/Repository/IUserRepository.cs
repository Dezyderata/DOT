using System.Threading.Tasks;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Infrastructure.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task Update(User user);
        Task<User> GetById(long id);
    }
}