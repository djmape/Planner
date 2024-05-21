using Planner.Models.PlannerTables;

namespace Planner.Models.Repositories
{
    public interface IEventsRepository
    {
        Task<int> AddEventAsync(Events e);
    }
}
