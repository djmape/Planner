using Planner.Models.PlannerTables;
using Planner.ViewModels;

namespace PlannerTestProject
{
    public class EventsTest
    {
        [Fact]
        private async Task EventIsViewed()
        {
            var events = new EventsMock();
            var eventsVM = new EventsViewModel(events);

            var selectedEvent = await events.EventSelected

        }
    }
}
