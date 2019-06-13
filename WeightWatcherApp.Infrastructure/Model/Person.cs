using System.Collections.Generic;

namespace WeightWatcherApp.Infrastructure.Model
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Hight { get; set; }
        public enum Sex
        {
            Woman, Man
        }

        public List<Measurement> Measurements { get; set; }
    }
}