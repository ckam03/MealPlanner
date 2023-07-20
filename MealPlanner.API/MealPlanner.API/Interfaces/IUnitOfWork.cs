namespace MealPlanner.API.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync(CancellationToken cancellationToken);
    }
}