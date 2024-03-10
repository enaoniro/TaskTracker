using GoalTracker.Models;

namespace GoalTracker.Data.Repository.IRepository
{
    public interface IGoalRepository : IRepository<Goal>
    {
        void Update(Goal goal);
     
    }
}
