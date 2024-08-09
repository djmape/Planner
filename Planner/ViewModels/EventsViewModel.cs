using System.Collections.ObjectModel;
using System.Windows.Input;
using Planner.Models.PlannerTables;
using Planner.Data;
using Planner.Models.Repositories;

namespace Planner.ViewModels
{
    public class EventsViewModel
    {
        private readonly IEventsRepository EventsRepository;
        public ICommand OnAddNewEventClickedCommand { get; private set; }
        public ICommand OnEventSelectedCommand { get; private set; }
        public ObservableCollection<Events> EventsCollection { get; private set; } = new();

        EventsDatabase database;
        public EventsViewModel(IEventsRepository eventsRepository)
        {

            EventsRepository = eventsRepository;
            database = new EventsDatabase();

            PopulateEventsList();

            OnAddNewEventClickedCommand = new Command(AddNewEventClicked);
            OnEventSelectedCommand = new Command(EventSelected);
        }
        private async void AddNewEventClicked()
        {
            await Shell.Current.GoToAsync("event_details");
        }

        private async void PopulateEventsList()
        {
            var events = await EventsRepository.ViewAllEventsAsync();

            foreach (var ev in events)
            {
                EventsCollection.Add(ev);
            }    
        }

        public async void EventSelected(object eventID)
        {
            Events selectedEvent = await EventsRepository.ViewEventAsync(Convert.ToInt32(eventID));

            await Shell.Current.GoToAsync($"event_details?events={selectedEvent}");
        }
    }
}
