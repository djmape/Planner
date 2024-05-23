using Planner.ViewModels;

namespace Planner.Views;

public partial class EventsPage : ContentPage
{
	public EventsPage(EventsViewModel eventsViewModel)
	{
		InitializeComponent();

		BindingContext = eventsViewModel;
	}
}