using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Planner.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Planner.Models.PlannerTables;
using Planner.Data;

namespace Planner.ViewModels
{
    internal class EventsViewModel
    {
        public ICommand OnAddNewEventClickedCommand { get; private set; }
        public ObservableCollection<Events> EventsCollection { get; private set; }
        public List<Events> GetAllEventsList { get; private set; }

        EventsDatabase database;
        public EventsViewModel()
        {
            database = new EventsDatabase();

            PopulateEventsList();

            OnAddNewEventClickedCommand = new Command(AddNewEventClicked);
        }
        private async void AddNewEventClicked()
        {
            await Shell.Current.GoToAsync("event_details");
        }

        private async void GetAllEvents()
        {
            GetAllEventsList = new();
            GetAllEventsList = await database.ViewAllEvents();
        }

        private void PopulateEventsList()
        {
            GetAllEvents();
            GetAllEventsList.Add(new Events()
            {
                EventTitle = GetAllEventsList.Count.ToString(),
                EventDescription = "appear"
            });
            EventsCollection = new ObservableCollection<Events>(GetAllEventsList);

        }
    }
}
