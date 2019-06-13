namespace WeightWatcherApp.Infrastructure.Model
{
    public class Measurement : Entity
    {
        public User User { get; set; }
        public float Bmi { get; set; }
        public float Weight { get; set; }

        public void countBmi()
        {
            Bmi = Weight / (User.Hight * User.Hight);
        }
    }
    
}