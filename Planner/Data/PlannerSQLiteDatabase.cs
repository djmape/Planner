using Planner.Models;
using Planner.Models.PlannerTables;
using SQLite;

namespace Planner.Data
{
    public class PlannerSQLiteDatabase
    {
        public SQLiteAsyncConnection Database { get; set; }

        public async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);

            var resultEventStatus = await Database.CreateTableAsync<EventStatus>();
            PopulateEventStatus();
            var resultEvents = await Database.CreateTableAsync<Events>();
        }
        public async Task<int> PopulateEventStatus()
        {
            string[] statusNames = { "Ongoing", "Upcoming", "Finished" };

            foreach (string name in statusNames)
            {
                EventStatus status = new();

                status.EventStatusName = name;

                await Init();
                await Database.InsertAsync(status);
            }

            return 0;
        }

    }
}
