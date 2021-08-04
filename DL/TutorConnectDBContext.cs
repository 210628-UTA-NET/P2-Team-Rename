using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DL.Entities;

namespace DL {
    public class TutorConnectDBContext : IdentityDbContext<User> {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<TutorApplication> TutorApplications { get; set; }
        public DbSet<DegreeCertification> DegreeCertifications { get; set; }
        public TutorConnectDBContext() : base() { }
        public TutorConnectDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Appointment>()
                .HasOne(a => a.Transaction)
                .WithOne(t => t.Appointment)
                .HasForeignKey<Transaction>(t => t.AppointmentId);

            builder.Entity<User>()
                .HasOne(u => u.IsTutor)
                .WithOne(t => t.User)
                .HasForeignKey<Tutor>(t => t.UserId);

            builder.Entity<Availability>();
            builder.Entity<Location>();
            builder.Entity<Message>();
            builder.Entity<Message>();
            builder.Entity<Payment>();
            builder.Entity<Review>();
            builder.Entity<Transaction>();
            builder.Entity<Tutor>();
            builder.Entity<DegreeCertification>();
            builder.Entity<TutorApplication>();
        }
    }
}