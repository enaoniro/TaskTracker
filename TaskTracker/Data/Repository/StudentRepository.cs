using GoalTracker.Data.Repository.IRepository;
using GoalTracker.Models;
using System.Linq.Expressions;

namespace GoalTracker.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        private readonly ApplicationDbContext _db;
      
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
      
        public void Update(Student student)
        {
            Student studentFromDb = _db.Students.FirstOrDefault(s => s.Id == student.Id);
            if (studentFromDb != null)
            {
                studentFromDb.Name = student.Name;
                studentFromDb.Email = student.Email;
                studentFromDb.Phone = student.Phone;
             if(studentFromDb.ImageUrl != null)
                {
                   studentFromDb.ImageUrl = student.ImageUrl;
                }
                
            }
            
        }
    }
}
