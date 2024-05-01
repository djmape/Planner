using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        public ObservableCollection<DayHour> DayHours { get; private set; }

        public ObservableCollection<Day> WeekDays {  get; private set; } 

        public DateTime dtDateTimeNow { get; private set; }

        public ICommand OnRangePickerChangedCommand { get; private set; }

        public ICommand OnDayArrowClickedCommand { get; private set; }

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _selectedRange;

        [ObservableProperty]
        public List<String> _rangePicker;

        public CalendarViewModel()
        {
            ListRange();

            OnRangePickerChangedCommand = new Command(OnRangePickerChanged);
            OnDayArrowClickedCommand = new Command(OnDayArrowClicked);

            DateTimeNow DateTimeNow = new DateTimeNow();

            dtDateTimeNow = DateTimeNow.RawDateTime;

            Title = DateTimeNow.RawDateTime.ToString("D");

            PopulateDay();
            PopulateWeek();

        }

        private void ListRange()
        {
            RangePicker = ["Day", "Week", "Month"];
        }

        private async void OnRangePickerChanged()
        {
            if (SelectedRange == 0) 
            {
                await Shell.Current.GoToAsync("day");
            }
            else if (SelectedRange == 1)
            {
                await Shell.Current.GoToAsync("week");
            }
            else if (SelectedRange == 2)
            {
                await Shell.Current.GoToAsync("month");
            }
        }  


        public void OnDayArrowClicked(object day)
        {
            dtDateTimeNow = dtDateTimeNow.AddDays(Convert.ToInt32(day));
            Title = dtDateTimeNow.ToString("D");
        }

        // Probably not necessary anymore ?
        private int DayOfWeekToInt(DateTime dayOfWeekNow)
        {
            string strDay = dayOfWeekNow.ToString();
            int intDay = 0;
            switch(strDay)
            {
                case "Monday":
                    return intDay + 1;
                case "Tuesday":
                    return intDay + 2;
                case "Wednesday":
                    return intDay + 3;
                case "Thursday":
                    return intDay + 4;
                case "Friday":
                    return intDay + 5;
                case "Saturday":
                    return intDay + 6;
                case "Sunday":
                    return intDay + 7;
            }

            return 0;
        }
        private void PopulateDay()
        {
            DateTimeNow dateTimeNow = new();
            DayHours = new ObservableCollection<DayHour>();

            DateTime dateTime = dateTimeNow.RawDateTime;
            DateTime nextDay = DateTime.Today.AddDays(1);

            while ( DateTime.Compare(dateTime, nextDay) < 1)
            {
                DayHours.Add(new DayHour()
                {
                    Hour = dateTime,
                    HourString = dateTime.ToString("HH:00")
                });

                dateTime = dateTime.AddHours(1);
            }
        }

        public void PopulateWeek()
        {
            DateTimeNow dtn = new DateTimeNow();

            int daysTillCurrentDate = dtn.RawDateTime.DayOfWeek - DayOfWeek.Monday;

            DateTime weekStartDate = dtn.RawDateTime.AddDays(-daysTillCurrentDate);

            WeekDays =
            [
                new Day()
                {
                    WeekDay =  weekStartDate.DayOfWeek,
                    Date = weekStartDate
                },
            ];

            for (int i = 1; i < 7; i++)
            {
                weekStartDate = weekStartDate.AddDays(1);

                WeekDays.Add(new Day() 
                {
                    WeekDay = weekStartDate.DayOfWeek,
                    Date = weekStartDate
                });
            }
        }
    }
}
