using Planner.ViewModels;

namespace Planner.Views;

public partial class MonthPage : ContentPage
{
	public MonthPage()
	{
		InitializeComponent();

		BindingContext = new CalendarViewModel();
	}
}