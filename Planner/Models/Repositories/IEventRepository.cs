using Planner.Models.PlannerTables;

namespace Planner.Models.Repositories
{
    public interface IEventsRepository
    {
        Task<int> AddEventAsync(Events e);

        Task<List<Events>> ViewAllEventsAsync();

        Task<Events> ViewEventAsync(int eventID);
    }
}
