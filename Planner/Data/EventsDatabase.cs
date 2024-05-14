using Planner.Models;
using Planner.Models.PlannerTables;
using SQLite;

namespace Planner.Data
{
    internal class EventsDatabase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            PlannerSQLiteDatabase mainDB = new();
            await mainDB.Init();
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public async Task<List<Events>> ViewAllEvents()
        {
            await Init();
            return await Database.Table<Events>().ToListAsync();
        }
        public async Task<List<Events>> ViewsAllEvents()
        {
            await Init();
            return await Database.Table<Events>().ToListAsync();
        }
    }
}
