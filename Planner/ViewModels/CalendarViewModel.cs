using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        public ObservableCollection<DayHour> DayHours { get; private set; }

        public DateTime dtDateTimeNow { get; private set; }

        public ICommand OnRangePickerChangedCommand { get; private set; }

        public ICommand OnDayArrowLeftClickedCommand { get; private set; }

        public ICommand OnDayArrowRightClickedCommand {  get; private set; }

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _selectedRange;

        public List<String> RangePicker;

        public CalendarViewModel()
        {
            ListRange();

            OnRangePickerChangedCommand = new Command(OnRangePickerChanged);
            OnDayArrowLeftClickedCommand = new Command(OnDayArrowLeftClicked);

            DateTimeNow DateTimeNow = new DateTimeNow();

            dtDateTimeNow = DateTimeNow.RawDateTime;

            Title = DateTimeNow.RawDateTime.ToString("D");

            PopulateDays();

        }

        private void ListRange()
        {
            RangePicker = new();
            RangePicker.Add("Day");

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

        private async void OnDayArrowLeftClicked()
        {
            dtDateTimeNow = dtDateTimeNow.AddDays(1);
            Title = dtDateTimeNow.ToString("D");
        }


        private void PopulateDays()
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
    }
}
