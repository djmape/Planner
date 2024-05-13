using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Planner.Models.PlannerTables
{
    public class EventStatus
    {
        [PrimaryKey, AutoIncrement]
        public int eventStatusID { get; set; }
        public string eventStatus { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Events> events { get; set; }
    }
}
