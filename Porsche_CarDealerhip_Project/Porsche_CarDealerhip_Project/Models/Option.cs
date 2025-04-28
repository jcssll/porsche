namespace Porsche_CarDealerhip_Project.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<CarOption> CarOptions { get; set; } = new List<CarOption>();
    }
}
