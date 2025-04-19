using Database.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class AppointmentSchedulerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=ASUS;Database=AppointmentScheduler;Trusted_Connection=True;TrustServerCertificate=True;ConnectRetryCount=0",
                sqlOptions => sqlOptions.EnableRetryOnFailure());
        }

        public DbSet<Appointment> ?Appointment { get; set; }
        public DbSet<Role> ?Role { get; set; }
        public DbSet<UserInfo> ?UserInfo { get; set; }
        public DbSet<Slots> ?Slots { get; set; }
        public DbSet<AppointmentStatus> ?AppointmentStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Always call base first

            // Add the TimeOnly? conversion for Slots.Slot
            modelBuilder.Entity<Slots>()
                .Property(e => e.Slot)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToTimeSpan() : (TimeSpan?)null,
                    v => v.HasValue ? TimeOnly.FromTimeSpan(v.Value) : (TimeOnly?)null
                );

            // Add other model configurations here if needed
        }
    }
}
