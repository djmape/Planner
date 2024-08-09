using Planner.Models.Repositories;
using Planner.ViewModels;

namespace Planner.Views;

public partial class EventPage : ContentPage
{
	public EventPage(EventViewModel eventViewModel)
	{
		InitializeComponent();

		BindingContext = eventViewModel;
	}
}