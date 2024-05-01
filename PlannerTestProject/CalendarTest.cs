using Planner.Models;
using Planner.ViewModels;
using System.Collections.ObjectModel;

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

        [Fact]

        public void GetHourNow()
        {
            DateTimeNow TestHourNow = new ();
            Assert.Equal(DateTime.Now.ToString("HH:00"), TestHourNow.GetHourNowString());
        }

        [Fact]
        public void AreHoursCorrect()

        {
            CalendarViewModel TestCalendarVM = new();
            ObservableCollection<DayHour> TestDayHour = new();

            DateTime testDateTimeToday = DateTime.Now;
            DateTime testNextDay = DateTime.Today.AddDays(1);

            while (DateTime.Compare(testDateTimeToday,testNextDay) < 0)
            {
                TestDayHour.Add(new DayHour()
                {
                    Hour = testDateTimeToday,
                    HourString = testDateTimeToday.ToString("HH:00")
                });

                testDateTimeToday = testDateTimeToday.AddHours(1);
            }

            List<string> tempVMHour = new();

            List<string> tempDayHour = new();

            for (int i = 0, count = TestDayHour.Count; i < count; i++)
            {
                tempVMHour.Add(TestDayHour[i].HourString);
            }

            for (int i = 0, count = TestCalendarVM.DayHours.Count; i < count; i++) 
            {
                tempDayHour.Add(TestCalendarVM.DayHours[i].HourString);
            }

            Assert.Equal(tempVMHour, tempDayHour);

        }

        [Fact]
        public void IsDateCorrectOnDayArrowClicked()
        {
            CalendarViewModel cvm = new CalendarViewModel();

            int[] day = { -1, 1 };
            Random random = new Random();
            Object prevOrNext = day[random.Next(day.Length)];

            cvm.OnDayArrowClicked(prevOrNext);
            Assert.Equal(DateTime.Now.AddDays(Convert.ToDouble(prevOrNext)).ToString("D"), cvm.Title);
        }

        [Fact]
        public void AllDaysInWeekCorrect()
        {
            CalendarViewModel cvm = new CalendarViewModel();

            cvm.PopulateWeek();

            Assert.Equal(DayOfWeek.Monday, cvm.WeekDays[0].WeekDay);
            Assert.Equal(DayOfWeek.Tuesday, cvm.WeekDays[1].WeekDay);
            Assert.Equal(DayOfWeek.Wednesday, cvm.WeekDays[2].WeekDay);
            Assert.Equal(DayOfWeek.Thursday, cvm.WeekDays[3].WeekDay);
            Assert.Equal(DayOfWeek.Friday, cvm.WeekDays[4].WeekDay);
            Assert.Equal(DayOfWeek.Saturday, cvm.WeekDays[5].WeekDay);
            Assert.Equal(DayOfWeek.Sunday, cvm.WeekDays[6].WeekDay);
        }
    }
}