using CommunityToolkit.Mvvm.ComponentModel;

namespace Planner.Models
{
    public class Day: ObservableObject
    {
        private DayOfWeek _weekDay;
        public DayOfWeek WeekDay
        {
            get => _weekDay;
            set => SetProperty(ref _weekDay, value);
        }

        private DateTime _dtDate;
        public DateTime DtDate
        {
            get => _dtDate;
            set => SetProperty(ref _dtDate, value);
        }

        private string _strDate;
        public String StrDate
        {
            get => _strDate;
            set => SetProperty(ref _strDate, value);
        }
    }
}
