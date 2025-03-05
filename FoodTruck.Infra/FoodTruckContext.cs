using FoodTruck.Domain;
using Microsoft.EntityFrameworkCore;

namespace FoodTruck.Infra
{
    public class FoodTruckContext : DbContext
    {
        public DbSet<User> Users { get; set; } // =  Les donnée dans la table dans notre DB 

        public FoodTruckContext(DbContextOptions<FoodTruckContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

