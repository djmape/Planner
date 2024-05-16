using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Data;
using Planner.Models;
using Planner.Models.PlannerTables;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class EventViewModel: ObservableObject
    {
        EventsDatabase eventsDatabase = new();
        public ICommand OnAddEventClickedCommand { get; private set; }

        [ObservableProperty]
        private string _eventTitle;
        [ObservableProperty]
        private string _eventDescription;
        [ObservableProperty]
        private DateTime _eventStartDate;
        [ObservableProperty]
        private DateTime _eventEndDate;
        [ObservableProperty]
        private DateTime _eventStartTime;
        [ObservableProperty]
        private DateTime _eventEndTime;

        public EventViewModel() 
        {
            InitializeForm();
            OnAddEventClickedCommand = new Command(OnAddEventClicked);
        }

        private void InitializeForm()
        {
            EventStartDate = DateTime.Now;
            EventEndDate = DateTime.Now;
            EventStartTime = DateTime.Now;
            EventEndTime = DateTime.Now;
        }
        private async void OnAddEventClicked()
        {
            Events e = new();
            e.EventTitle = EventTitle;
            e.EventDescription = EventDescription;
            e.EventStartDate = EventStartDate;
            e.EventEndDate = EventEndDate;
            e.EventStartTime = EventStartTime;
            e.EventEndTime = EventEndTime;
            e.EventStatusID = CalculateEventStatus();

            await eventsDatabase.SaveEventAsync(e);
        }

        private int CalculateEventStatus()
        {
            DateTimeNow now = new();

            var nowDate = DateOnly.FromDateTime(now.RawDateTime);
            var nowTime = TimeOnly.FromDateTime(now.RawDateTime);
            var startDate = DateOnly.FromDateTime(EventStartDate);
            var startTime = TimeOnly.FromDateTime(EventStartDate);
            var endDate = DateOnly.FromDateTime(EventEndDate);
            var endTime = TimeOnly.FromDateTime(EventEndTime);

            if ((startDate ==  nowDate && startTime >= nowTime) &&
                ( endDate <= nowDate && endTime < nowTime))
            {
                return 1;
            }
            else if (startDate > nowDate || (startDate == nowDate && startTime > nowTime))
            {
                return 2;
            }
            else if (endDate < nowDate || (endDate == nowDate && endTime < nowTime))
            {
                return 3;
            }

            return 0;
        }
    }
}
