using Planner.Models;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using SQLiteNetExtensions.Attributes;
using ExtAttributes = SQLiteNetExtensions.Attributes;

namespace Planner.Models.PlannerTables
{
    public class Events
    {
        [PrimaryKey, AutoIncrement]
        public int EventID  { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }

        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventStartTime { get; set; }

        public DateTime eventEndTime { get; set;}

        [ExtAttributes.ForeignKey(typeof(EventStatus))]
        public int EventStatusID { get; set; }

        [ManyToOne]
        public EventStatus EventStatus { get; set; }

    }
}
