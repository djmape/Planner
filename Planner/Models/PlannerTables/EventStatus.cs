using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Planner.Models.PlannerTables
{
    public class EventStatus
    {
        [PrimaryKey, AutoIncrement]
        public int EventStatusID { get; set; }
        public string EventStatusName { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Events> events { get; set; }

        public EventStatus()
        {
            
        }
    }
}
