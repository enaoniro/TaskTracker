namespace GoalTracker.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IGoalRepository Goal { get; }
        IStudentRepository Student { get; }
        void Save();
       

    }
}
