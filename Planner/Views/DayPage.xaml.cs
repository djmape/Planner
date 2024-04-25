using Planner.ViewModels;

namespace Planner.Views;

public partial class DayPage : ContentPage
{
	public DayPage()
	{
		InitializeComponent();

        BindingContext = new CalendarViewModel();
    }
}