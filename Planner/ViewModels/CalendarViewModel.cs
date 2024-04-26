using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class CalendarViewModel : ObservableObject
    {
        public ObservableCollection<Calendar> DayDetails { get; private set; }

        public ICommand OnRangePickerChangedCommand { get; private set; }

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private int _selectedRange;

        private List<String> rangePicker;
        public List<String> RangePicker 
        {
            get
            {
                return rangePicker;
            }

            set
            {
                OnRangePickerChangedCommand = new Command(OnRangePickerChanged);
            }
         }

        public CalendarViewModel()
        {
            ListRange();

            DateTimeNow dateTimeNow = new DateTimeNow();

            Title = dateTimeNow.RawDateTime.ToString();

            DayDetails = new ObservableCollection<Calendar>
            {
                new Calendar { Date = dateTimeNow.GetDateTodayString()},
                new Calendar { Date = dateTimeNow.GetTimeNowString()},
                new Calendar { Date = "Three"}
            };
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

        private async void PopulateDays()
        {

        }
    }
}
