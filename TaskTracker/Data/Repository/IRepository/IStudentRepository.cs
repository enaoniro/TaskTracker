using GoalTracker.Models;

namespace GoalTracker.Data.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
    
        void Update(Student student);
    }
}
