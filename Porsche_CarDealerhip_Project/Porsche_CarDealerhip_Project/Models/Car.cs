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

        public ICollection<CarOption> CarOptions { get; set; } = new List<CarOption>();
    }
}
