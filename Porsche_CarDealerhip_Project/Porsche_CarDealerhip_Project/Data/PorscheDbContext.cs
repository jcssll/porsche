using Microsoft.EntityFrameworkCore;
using Porsche_CarDealerhip_Project.Models;


namespace Porsche_CarDealerhip_Project.Data
{
    public class PorscheDbContext : DbContext
    {
        public PorscheDbContext(DbContextOptions<PorscheDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<CarOption> CarOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOption>()
                .HasOne(co => co.Car)
                .WithMany(c => c.CarOptions)
                .HasForeignKey(co => co.CarId);

            modelBuilder.Entity<CarOption>()
                .HasOne(co => co.Option)
                .WithMany(o => o.CarOptions)
                .HasForeignKey(co => co.OptionId);
        }


    }
}
