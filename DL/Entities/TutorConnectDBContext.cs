using Microsoft.EntityFrameworkCore;

namespace DL.Entities
{
    public class TutorConnectDBContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<User> Users { get; set; }
        public TutorConnectDBContext() : base()
        { }
        public TutorConnectDBContext(DbContextOptions p_options) : base(p_options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder p_optionsBuilder)
        {
            p_optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    

}