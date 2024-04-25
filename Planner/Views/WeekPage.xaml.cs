using Planner.ViewModels;

namespace Planner.Views;

public partial class WeekPage : ContentPage
{
	public WeekPage()
	{
		InitializeComponent();

		BindingContext = new CalendarViewModel();
	}
}