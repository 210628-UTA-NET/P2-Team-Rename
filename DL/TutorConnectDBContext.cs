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
        public TutorConnectDBContext(DbContextOptions p_options) : base(p_options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder p_optionsBuilder)
        {
            p_optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            base.OnModelCreating(p_modelBuilder);
            p_modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Transaction)
                .WithOne(t => t.Appointment)
                .HasForeignKey<Transaction>(t => t.AppointmentID);
            p_modelBuilder.Entity<Availability>();
            p_modelBuilder.Entity<Location>();
            p_modelBuilder.Entity<Message>();
            p_modelBuilder.Entity<Message>();
            p_modelBuilder.Entity<Payment>();
            p_modelBuilder.Entity<Review>();
            p_modelBuilder.Entity<Topic>();
            p_modelBuilder.Entity<Transaction>();
            p_modelBuilder.Entity<Tutor>();
            p_modelBuilder.Entity<User>()
                .HasOne(u => u.Tutor)
                .WithOne(t => t.User)
                .HasForeignKey<Tutor>(t => t.UserID);
        }
    }

    

}