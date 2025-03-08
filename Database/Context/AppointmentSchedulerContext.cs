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
        public DbSet<Mode> ?Mode { get; set; }
        public DbSet<UserInfo> ?UserInfo { get; set; }
    }
}
