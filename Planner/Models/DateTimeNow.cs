namespace Planner.Models
{
    public class DateTimeNow
    {
        public DateTime RawDateTime { get; set; }

        public DateTimeNow()
        {
            RawDateTime = DateTime.Now;
        }

        public string GetDateTodayString()
        {
            return RawDateTime.ToString("D");
        }

        public string GetTimeNowString()
        {
            return RawDateTime.ToString("HH:mm");
        }

    }
}
