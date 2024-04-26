using Planner.Models;
using Planner.ViewModels;

namespace PlannerTestProject
{
    public class CalendarTest
    {
        public CalendarTest()
        {

        }

        [Fact]
        public void GetDateToday()
        {
            DateTimeNow TestDateTimeNow = new ();
            Assert.Equal(DateTime.Now.Date.ToString("D"), TestDateTimeNow.GetDateTodayString());
        }

        [Fact]

        public void GetTimeNow()
        {
            DateTimeNow TestDateTimeNow = new ();
            Assert.Equal(DateTime.Now.ToString("HH:mm"), TestDateTimeNow.GetTimeNowString());
        }
    }
}