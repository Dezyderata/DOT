using System.Threading.Tasks;
using WeightWatcherApp.Contract.UserDto;


namespace WeightWatcherApp.Core.Services
{
    public interface IUserService : IService<UserDto>
    {
        Task Update(UserDto userDto);
        Task<UserDto> GetById(long id);
        Task Add(UserDto entity);
    }
}