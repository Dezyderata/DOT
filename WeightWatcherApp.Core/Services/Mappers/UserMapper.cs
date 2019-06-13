using System.Collections.Generic;
using WeightWatcherApp.Contract.UserDto;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Core.Services.Mappers
{
    internal static class UserMapper
    {
           public static UserDto UserDtoMapper(User user)
                {
                    return new UserDto()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Hight = user.Hight,
                        MeasurementsD = MeasurementMapper.MeasurementDtosMapper(user.Measurements)
                    };
                }
           public static User DtoUserMapper(UserDto userDto)
           {
               return new User()
               {
                   Id = userDto.Id,
                   FirstName = userDto.FirstName,
                   LastName = userDto.LastName,
                   Hight = userDto.Hight,
                   
                    
               };
           }
    }
}