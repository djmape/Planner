using Planner.Data;
using Planner.Models.PlannerTables;

namespace Planner.Models.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        PlannerSQLiteDatabase MainDB { get; set; } = new();

        public async Task<List<Events>> ViewAllEventsAsync()
        {
            await MainDB.Init();
            return await MainDB.Database.Table<Events>().ToListAsync();
        }

        public async Task<int> AddEventAsync(Events e)
        {
            await MainDB.Init();

            return await MainDB.Database.InsertAsync(e);
        }

        public async Task<Events> ViewEventAsync(int eventID)
        {
            await MainDB.Init();

            return await MainDB.Database.Table<Events>().Where(i => i.EventID == eventID).FirstOrDefaultAsync();
        }
    }
}
