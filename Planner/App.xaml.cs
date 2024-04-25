using Planner.Views;
using Planner.ViewModels;

namespace Planner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
