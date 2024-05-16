using Planner.Models;
using Planner.Models.PlannerTables;
using SQLite;

namespace Planner.Data
{
    internal class EventsDatabase
    {
        PlannerSQLiteDatabase MainDB { get; set; } = new();

        public async Task<List<Events>> ViewAllEventsAsync()
        {
            await MainDB.Init();
            return await MainDB.Database.Table<Events>().ToListAsync();
        }

        public async Task<int> SaveEventAsync(Events e)
        {
            await MainDB.Init();

            return await MainDB.Database.InsertAsync(e);
        }
    }
}
