using CommunityToolkit.Mvvm.ComponentModel;
using Planner.Data;
using Planner.Models;
using Planner.Models.PlannerTables;
using Planner.Models.Repositories;
using System.Windows.Input;

namespace Planner.ViewModels
{
    public partial class EventViewModel: ObservableObject
    {
        private readonly IEventsRepository EventsRepository;
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
        [ObservableProperty]
        private int _eventStatus;

        public EventViewModel(IEventsRepository eventsRepository) 
        {
            EventsRepository = eventsRepository;

            InitializeForm();
            OnAddEventClickedCommand = new Command(OnAddEventClicked);
        }

        public EventViewModel(Events events)
        {
            EventTitle = events.EventTitle;
            EventDescription = events.EventDescription;
            EventStartDate = events.EventStartDate;
            EventEndDate = events.EventEndDate;
            EventStartDate = events.EventEndDate;
            EventEndTime = events.EventEndTime;
            EventStatus = events.EventStatusID;
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

            await EventsRepository.AddEventAsync(e);
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
