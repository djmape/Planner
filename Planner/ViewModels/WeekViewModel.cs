using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using Planner.Models;
using System.Collections.ObjectModel;

namespace Planner.ViewModels
{
    internal class WeekViewModel
    {
        public ObservableCollection<Week> WeekDetails { get; private set; }

        public WeekViewModel()
        {
            WeekDetails = new ObservableCollection<Week>
            {
                new Week { Date = "One" },
                new Week { Date = "Two" },
                new Week { Date = "Three" }
            };
        }
    }
}
