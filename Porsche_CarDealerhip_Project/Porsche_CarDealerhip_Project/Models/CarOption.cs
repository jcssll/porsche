namespace Porsche_CarDealerhip_Project.Models
{
    public class CarOption
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int OptionId { get; set; }

        public Car Car { get; set; } = null!;

        public Option Option { get; set; } = null!;
    }
}
