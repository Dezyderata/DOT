using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeightWatcherApp.Contract.MeasurementDto;
using WeightWatcherApp.Contract.UserDto;
using WeightWatcherApp.Core.Services.Mappers;
using WeightWatcherApp.Infrastructure.Model;
using WeightWatcherApp.Infrastructure.Repository;

namespace WeightWatcherApp.Core.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _iMeasurementRepository;

        public MeasurementService(IMeasurementRepository iMeasurementRepository)
        {
            _iMeasurementRepository = iMeasurementRepository;
        }


        public async Task Add(MeasurementDto entity, UserDto userDto)
        {
            await _iMeasurementRepository.Add(MeasurementMapper.DtoMeasurementMapper(entity, userDto));
        }

        public async Task Delete(long id)
        {
            await _iMeasurementRepository.Delete(id);
        }

        public async Task<IEnumerable<MeasurementDto>> GetAll(long id)
        {
            var measurements = await _iMeasurementRepository.GetAll(id);
            return MeasurementMapper.MeasurementDtosMapper(measurements);

        }

        public async Task<IEnumerable<MeasurementDto>> GetByDate(DateTime start, DateTime stop)
        {
            var measurements = await _iMeasurementRepository.GetByDate(start, stop);
            return MeasurementMapper.MeasurementDtosMapper(measurements);
        }

      
    }
}