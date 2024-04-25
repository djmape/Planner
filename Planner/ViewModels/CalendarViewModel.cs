using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public List<String> RangePicker { get; set; }

        public CalendarViewModel()
        {
            ListRange();

            Title = DateTimeNow.DateTodayToString();

            OnRangePickerChangedCommand = new Command(OnRangePickerChanged);

            DayDetails = new ObservableCollection<Calendar>
            {
                new Calendar { Date = "One"},
                new Calendar { Date = "Two"},
                new Calendar { Date = "Three"}
            };
        }

        private void ListRange()
        {
            RangePicker = new List<String>();

            RangePicker.Add("Day");
            RangePicker.Add("Week");
            RangePicker.Add("Month");
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
