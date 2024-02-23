using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;

namespace TaskTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 1,
                   Name = "Iso",
                   Email = "can@gmail.com",
                   GroupId = 1,
                   Phone = "12222333"
               },
                new Student
                {
                    Id = 2,
                    Name = "sos",
                    Email = "sos@gmail.com",
                    GroupId = 1,
                    Phone = "1244444"
                }
            );
        }
    }
}
