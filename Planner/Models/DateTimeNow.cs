namespace Planner.Models
{
    internal class DateTimeNow
    {
        public DateTime RawDateTime { get; private set; }

        public string DateTodayToString()
        {
            return RawDateTime.Today.Date.ToString("D");
        }

        public string TimeNowToString()
        {
            return RawDateTime.Now.ToString("HH:mm");
        }

        private DateTime GetDateTimeNow() 
        { 
            RawDateTime = DateTime.Now;
        }
    }
}
