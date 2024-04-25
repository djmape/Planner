using Planner.ViewModels;

namespace PlannerTestProject
{
    public class CalendarTest
    {
        [Fact]
        public void GetDateToday()
        {
            var calendar = new CalendarViewModel();
            Assert.Equal(DateTime.Today.Date.ToString("D"), calendar.Title);
        }


    }
}