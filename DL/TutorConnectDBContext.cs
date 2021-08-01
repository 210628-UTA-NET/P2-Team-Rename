using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DL.Entities;

namespace DL
{
    public class TutorConnectDBContext : IdentityDbContext<User>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public TutorConnectDBContext() : base()
        { }
        public TutorConnectDBContext(DbContextOptions options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Transaction)
                .WithOne(t => t.Appointment)
                .HasForeignKey<Transaction>(t => t.AppointmentID);
            modelBuilder.Entity<Availability>();
            modelBuilder.Entity<Location>();
            modelBuilder.Entity<Message>();
            modelBuilder.Entity<Message>();
            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Review>();
            modelBuilder.Entity<Topic>();
            modelBuilder.Entity<Transaction>();
            modelBuilder.Entity<Tutor>();
            modelBuilder.Entity<User>()
                .HasOne(u => u.Tutor)
                .WithOne(t => t.User)
                .HasForeignKey<Tutor>(t => t.UserID);
        }
    }

    

}