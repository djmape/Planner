using Planner.ViewModels;

namespace Planner.Views;

public partial class EventsPage : ContentPage
{
	public EventsPage()
	{
		InitializeComponent();

		BindingContext = new EventsViewModel();
	}
}