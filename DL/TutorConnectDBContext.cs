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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Appointment>()
                .HasOne(a => a.Transaction)
                .WithOne(t => t.Appointment)
                .HasForeignKey<Transaction>(t => t.AppointmentID);
            builder.Entity<Availability>();
            builder.Entity<Location>();
            builder.Entity<Message>();
            builder.Entity<Message>();
            builder.Entity<Payment>();
            builder.Entity<Review>();
            builder.Entity<Topic>();
            builder.Entity<Transaction>();
            builder.Entity<Tutor>();
            builder.Entity<User>()
                .HasOne(u => u.Tutor)
                .WithOne(t => t.User)
                .HasForeignKey<Tutor>(t => t.UserID);
        }
    }

    

}