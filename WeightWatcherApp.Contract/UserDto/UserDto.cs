using System;
using System.Collections.Generic;

namespace WeightWatcherApp.Contract.UserDto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Hight { get; set; }
        
        public IEnumerable<MeasurementDto.MeasurementDto> MeasurementsD { get; set; }
    }
}