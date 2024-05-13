using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Planner.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Planner.Models.PlannerTables;

namespace Planner.ViewModels
{
    internal class EventsViewModel
    {
        readonly IList<Events> eventsList;

        public ICommand OnAddNewEventClickedCommand { get; private set; }
        public ObservableCollection<Events> EventsCollection { get; private set; }

        public EventsViewModel()
        {
            eventsList = new List<Events>();
            PopulateEventsList();

            OnAddNewEventClickedCommand = new Command(AddNewEventClicked);
        }
        private async void AddNewEventClicked()
        {
            await Shell.Current.GoToAsync("event_details");
        }

        private void PopulateEventsList()
        {

            eventsList.Add(new Events
            {
                EventTitle = "Title 1",
                EventDescription = "Description 1"
            });

            eventsList.Add(new Events
            {
                EventTitle = "Title 2",
                EventDescription = "Description 2"
            });

            EventsCollection = new ObservableCollection<Events>(eventsList);
        }
    }
}
