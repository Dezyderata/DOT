using System;

namespace WeightWatcherApp.Contract.MeasurementDto
{
    public class MeasurementDto
    {
        //public UserDto.UserDto UserDto { get; set; }
       // public long userId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public float Weight { get; set; }
        public float Bmi { get; set; }
        public long Id { get; set; }
    }
}