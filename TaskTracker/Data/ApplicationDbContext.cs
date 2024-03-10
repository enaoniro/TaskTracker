using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using GoalTracker.Models;
using Goal = GoalTracker.Models.Goal;

namespace GoalTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Goal> Goals { get; set; }
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

            modelBuilder.Entity<Models.Goal>().HasData(
                new Goal

                {
                    Id = 3,
                    Name = "reading",
                    AssignmentDate = DateTime.Now,
                    Deadline = DateTime.Now,
                    StudentId = 2,
                    

                }
                ,
                 new Goal 
                 {
                    Id = 4,
                    Name = "writing",
                    AssignmentDate = DateTime.Now,
                    Deadline =new  DateTime(2024, 2,28),
                    StudentId = 2,
                    

                }

                
           );
        }
    }
}
