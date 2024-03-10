using GoalTracker.Data.Repository.IRepository;
using GoalTracker.Models;
using System.Linq.Expressions;

namespace GoalTracker.Data.Repository
{
    public class GoalRepository :Repository<Goal>, IGoalRepository
    {
        private ApplicationDbContext _db;
        public GoalRepository(ApplicationDbContext db) : base(db)
        {
           _db = db;
        }

        public void Update(Goal goal)
        {
            _db.Goals.Update(goal);
        }
    }
}
