using Planner.Views;

namespace Planner
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("day", typeof(Views.DayPage));
            Routing.RegisterRoute("week", typeof(Views.WeekPage));
            Routing.RegisterRoute("month", typeof(Views.MonthPage));
            Routing.RegisterRoute("event_details", typeof(Views.EventPage));
        }
    }
}
