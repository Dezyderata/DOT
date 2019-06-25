using System;

namespace WeightWatcherApp.Contract.MeasurementDto
{
    public class MeasurementDto
    {
        public DateTime DateOfCreation { get; set; }
        public float Weight { get; set; }
        public float Bmi { get; set; }
        public long Id { get; set; }
    }
}