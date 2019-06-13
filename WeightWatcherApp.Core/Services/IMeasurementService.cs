using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightWatcherApp.Contract.MeasurementDto;
using WeightWatcherApp.Contract.UserDto;

namespace WeightWatcherApp.Core.Services
{
    public interface IMeasurementService : IService<MeasurementDto>
    {
        Task<IEnumerable<MeasurementDto>> GetAll(long id);
        Task<IEnumerable<MeasurementDto>> GetByDate(DateTime start, DateTime stop);
        Task Add(MeasurementDto entity, UserDto userDto);
    }
}