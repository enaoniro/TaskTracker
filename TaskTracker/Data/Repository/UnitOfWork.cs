using GoalTracker.Data.Repository.IRepository;

namespace GoalTracker.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
       {

        private readonly ApplicationDbContext _db;
        public IGoalRepository Goal { get; private set; }
        public IStudentRepository Student { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Goal = new GoalRepository(_db);
            Student = new StudentRepository(_db);

        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
