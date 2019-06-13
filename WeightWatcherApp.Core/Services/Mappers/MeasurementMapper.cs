using System.Collections.Generic;
using System.Linq;
using WeightWatcherApp.Contract.MeasurementDto;
using WeightWatcherApp.Contract.UserDto;
using WeightWatcherApp.Infrastructure.Model;

namespace WeightWatcherApp.Core.Services.Mappers
{
    internal static class MeasurementMapper
    {
          public static Measurement DtoMeasurementMapper(MeasurementDto measurementDto, UserDto userDto)
                {

                    return new Measurement()
                    {
                        User = Mappers.UserMapper.DtoUserMapper(userDto),
                        Weight = measurementDto.Weight
                       
                    };
                }
        
          public static IEnumerable<MeasurementDto> MeasurementDtosMapper(IEnumerable<Measurement> measurements)
                {
                    return measurements.Select(x => new MeasurementDto()
                        {
                        
                            DateOfCreation = x.DateOfCreation,
                            Weight = x.Weight,
                            Bmi = x.Bmi,
                            Id = x.Id
                        }
                    ).ToList();
                }
    }
}