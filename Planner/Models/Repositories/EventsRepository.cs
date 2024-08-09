using Planner.Data;
using Planner.Models.PlannerTables;
using SQLite;

namespace Planner.Models.Repositories
{
    public class EventsRepository : IEventsRepository
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

        public async Task<List<Events>> ViewAllEventsAsync()
        {
            await Init();
            return await Database.Table<Events>().ToListAsync();
        }

        public async Task<int> AddEventAsync(Events e)
        {
            await Init();

            return await Database.InsertAsync(e);
        }

        public async Task<Events> ViewEventAsync(int eventID)
        {
            await Init();

            return await Database.Table<Events>().Where(i => i.EventID == eventID).FirstOrDefaultAsync();
        }
    }
}
