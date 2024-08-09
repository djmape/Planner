using Planner.Models.PlannerTables;
using Planner.Models.Repositories;
using Planner.ViewModels;
using PlannerTestProject.Mocks;

namespace PlannerTestProject
{
    public class EventsTest
    {
        [Fact]
        private async Task EventIsViewed()
        {
            IEventsRepository eventsRepository = new EventsRepositoryMock();

            var events = new EventsViewModel(eventsRepository);

            var selectedEvent = await events.EventSelected(1);

        }
    }
}
