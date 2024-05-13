using Planner.Models;
using Planner.Models.PlannerTables;
using SQLite;

namespace Planner.Data
{
    public class PlannerSQLiteDatabase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            var resultEventStatus = await Database.CreateTableAsync<EventStatus>();
            var resultEvents = await Database.CreateTableAsync<Events>();
        }

        public async Task<List<Events>> ViewAllEvents()
        {
            await Init();
            return await Database.Table<Events>().ToListAsync();
        }
    }
}
