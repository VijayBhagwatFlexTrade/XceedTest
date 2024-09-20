using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
	public class MyDataTableVM : ObservableObject
	{
		public DateTime Today { get; set; }
		public DateTime SelectedDateTime { get; set; }
		public CalendarBlackoutDatesCollection SettlementBlackoutDates { get; private set; }
		public ICommand Add2Day2HolidayCmd { get; private set; }
		private List<CalendarDateRange> blockedDates;

		public MyDataTableVM()
		{
			Add2Day2HolidayCmd = new RelayCommand(add2day2holidayExec);
			blockedDates = new List<CalendarDateRange>();
			blockedDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
			blockedDates.Add(new CalendarDateRange(DateTime.Today.AddDays(3)));
			SelectedDateTime = Today = DateTime.Today;
			updateBlockedDates();
		}

		private void add2day2holidayExec()
		{
			blockedDates.Add(new CalendarDateRange(DateTime.Today.AddDays(1)));
			updateBlockedDates();
		}

		private void updateBlockedDates()
		{
			SettlementBlackoutDates = new CalendarBlackoutDatesCollection(new Calendar());
			foreach (var r in blockedDates)
			{
				SettlementBlackoutDates.Add(r);
			}
			RaisePropertyChanged(nameof(SettlementBlackoutDates));
		}
	}
}
