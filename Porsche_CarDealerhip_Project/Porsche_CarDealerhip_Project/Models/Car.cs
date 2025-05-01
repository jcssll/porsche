namespace Porsche_CarDealerhip_Project.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        public bool HasSunRoof { get; set; }
        public bool Has4WheelDrive { get; set; }
        public bool HasLowMiles { get; set; }
        public bool HasPowerWindows { get; set; }
        public bool HasNavigation { get; set; }
        public bool HasHeatedSeats { get; set; }

        public ICollection<CarOption> CarOptions { get; set; } = new List<CarOption>();
    }
}
