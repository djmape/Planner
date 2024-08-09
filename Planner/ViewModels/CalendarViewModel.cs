using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class CalendarViewModel : ObservableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler WeekDaysChanged;
        public event PropertyChangedEventHandler MonthDaysChanged;
        public ObservableCollection<DayHour> DayHours { get; private set; }

        private ObservableCollection<Day> _weekDays;
        public ObservableCollection<Day> WeekDays 
        {
            get
            {
                return _weekDays;
            }
            set
            {
                _weekDays = value;
                OnWeekDaysChanged();
            }
        
        }

        private ObservableCollection<Day> _monthDays;
        public ObservableCollection<Day> MonthDays
        {
            get
            {
                return _monthDays;
            }
            set
            {
                _monthDays = value;
                OnMonthDaysChanged();
            }
        }

        public DateTime dtDateTimeNow { get; private set; }

        public DateTime selectedDateTime { get; private set; }

        public ICommand OnRangePickerChangedCommand { get; private set; }
        public ICommand OnDayArrowClickedCommand { get; private set; }
        public ICommand OnWeekArrowClickedCommand { get; private set; }
        public ICommand OnMonthArrowClickedCommand { get; private set; }

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
            OnWeekArrowClickedCommand = new Command(OnWeekArrowClicked);
            OnMonthArrowClickedCommand = new Command(OnMonthArrowClicked);

            DateTimeNow DateTimeNow = new DateTimeNow();

            dtDateTimeNow = DateTimeNow.RawDateTime;

            Title = DateTimeNow.RawDateTime.ToString("D");

            selectedDateTime = DateTimeNow.RawDateTime;

            PopulateDay();
            PopulateWeek();
            PopulateMonth();

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

        public void OnWeekArrowClicked(object week)
        {

            for (int i = 0; i < 7; i++) 
            {
                WeekDays[i].DtDate = WeekDays[i].DtDate.AddDays(Convert.ToInt32(week));
                WeekDays[i].StrDate = WeekDays[i].DtDate.ToString("MMMM dd");
            }


        }

        protected void OnWeekDaysChanged([CallerMemberName] string _weekDays = null)
        {
            WeekDaysChanged?.Invoke(this, new PropertyChangedEventArgs(_weekDays));
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
                    DtDate = weekStartDate,
                    StrDate = weekStartDate.ToString("MMMM dd")
                },
            ];

            DateTime dateQueued = weekStartDate;

            for (int i = 1; i < 7; i++)
            {
                dateQueued = dateQueued.AddDays(1);

                WeekDays.Add(new Day() 
                {
                    WeekDay = dateQueued.DayOfWeek,
                    DtDate = dateQueued,
                    StrDate = dateQueued.ToString("MMMM dd")
                });
            }
        }

        public void OnMonthArrowClicked(object month)
        {
            selectedDateTime = selectedDateTime.AddMonths(Convert.ToInt32(month));
            Title = selectedDateTime.ToString("MMMM");

            DateTimeNow dtn = new();
            PopulateMonth(selectedDateTime);
        }

        protected void OnMonthDaysChanged([CallerMemberName] string _weekMonths = null)
        {
            MonthDaysChanged?.Invoke(this, new PropertyChangedEventArgs(_weekMonths));
        }

        public void PopulateMonth()
        {
            DateTime dt = selectedDateTime;
            DateTime dateQueued = dt;

            // Get first day on month calendar
            while(dateQueued.Month > dt.AddMonths(-1).Month || dateQueued.DayOfWeek != DayOfWeek.Monday)
            {
                dateQueued = dateQueued.AddDays(-1);
            }

            // Get last day on month calendar
            // Add days to month collection

            MonthDays = new();

            for (int i = 0; i < 7; i++)
            {
                MonthDays.Add(new Day()
                {
                    StrDate = dateQueued.AddDays(i).DayOfWeek.ToString()
                });
            }

            while((dateQueued.Month != dt.AddMonths(1).Month) || (dateQueued.DayOfWeek != DayOfWeek.Monday))
            {
                MonthDays.Add(new Day()
                {
                    WeekDay = dateQueued.DayOfWeek,
                    DtDate = dateQueued,
                    StrDate = dateQueued.ToString("MMMM dd")
                });

                dateQueued = dateQueued.AddDays(1);
            }

            selectedDateTime = dt;
        }

        public void PopulateMonth(DateTime dt)
        {
            DateTime dateQueued = new DateTime(dt.Year, dt.Month, 1);

            // Get first day on month calendar
            while (dateQueued.DayOfWeek != DayOfWeek.Monday)
            {
                dateQueued = dateQueued.AddDays(-1);
            }

            // Get last day on month calendar
            // Add days to month collection

            for (int i = 7, count = MonthDays.Count; i < count; i++) 
            {
                MonthDays[i].DtDate = dateQueued;
                MonthDays[i].WeekDay = dateQueued.DayOfWeek;
                MonthDays[i].StrDate = dateQueued.ToString("MMMM dd");

                dateQueued = dateQueued.AddDays(1);
            }

            selectedDateTime = dt;
        }
    }
}
