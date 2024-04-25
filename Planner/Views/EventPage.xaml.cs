using Planner.ViewModels;

namespace Planner.Views;

public partial class EventPage : ContentPage
{
	public EventPage()
	{
		InitializeComponent();

		BindingContext = new EventViewModel();
	}
}