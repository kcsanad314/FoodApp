using InspectionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Inspection> Inspections { get; set; }

        public DbSet<InspectionType> InspectionTypes { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Restaurant)
                .WithOne(r => r.User)
                .HasForeignKey<Restaurant>(r => r.UserId);

            modelBuilder.Entity<Food>()
                .HasOne(f => f.Restaurant)
                .WithMany(r => r.Foods)
                .HasForeignKey(f => f.RestaurantId);
        }
    }
}
