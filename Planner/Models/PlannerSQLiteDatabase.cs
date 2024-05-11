using SQLite;

namespace Planner.Models
{
    internal class PlannerSQLiteDatabase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Events>();
        }
    }
}
