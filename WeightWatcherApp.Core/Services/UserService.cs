using System.Collections.Generic;
using System.Threading.Tasks;
using WeightWatcherApp.Contract.UserDto;
using WeightWatcherApp.Infrastructure.Model;
using WeightWatcherApp.Infrastructure.Repository;
using WeightWatcherApp.Core.Services.Mappers;

namespace WeightWatcherApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;

        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task Add(UserDto entity)
        {
            await _iUserRepository.Add(UserMapper.DtoUserMapper(entity));
        }

        public async Task Delete(long id)
        {
            await _iUserRepository.Delete(id);
        }

        public async Task Update(UserDto userDto)
        {
            await _iUserRepository.Update(UserMapper.DtoUserMapper(userDto));
        }

        public async Task<UserDto> GetById(long id)
        {
            var user = await _iUserRepository.GetById(id);
            return UserMapper.UserDtoMapper(user);
        }
     
    }
}