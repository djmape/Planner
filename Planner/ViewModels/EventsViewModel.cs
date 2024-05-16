using System.Collections.ObjectModel;
using System.Windows.Input;
using Planner.Models.PlannerTables;
using Planner.Data;

namespace Planner.ViewModels
{
    internal class EventsViewModel
    {
        public ICommand OnAddNewEventClickedCommand { get; private set; }
        public ICommand OnEventSelectedCommand { get; private set; }
        public ObservableCollection<Events> EventsCollection { get; private set; } = new();

        EventsDatabase database;
        public EventsViewModel()
        {
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
            var events = await database.ViewAllEventsAsync();

            foreach (var ev in events)
            {
                EventsCollection.Add(ev);
            }    
        }

        private async void EventSelected()
        {

        }
    }
}
