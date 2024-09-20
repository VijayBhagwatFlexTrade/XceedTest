using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
	//// Adds a collection of command bindings to a date picker's existing BlackoutDates collection, since the collections are immutable and can't be bound to otherwise.
	//// Usage: <DatePicker hacks:AttachedProperties.BlackoutDates="{Binding BlackoutDates}" >
	//public class DateTimePickerAttachedProperties : DependencyObject
	//{
	//    #region Attributes

	//    private static readonly List<Calendar> _calendars = new List<Calendar>();
	//    private static readonly List<DatePicker> _datePickers = new List<DatePicker>();

	//    #endregion

	//    #region Dependency Properties

	//    public static DependencyProperty BlackoutDatesProperty = DependencyProperty.RegisterAttached("BlackoutDates", typeof(ObservableCollection<DateTime>), typeof(DateTimePickerAttachedProperties), new PropertyMetadata(null, OnRegisterCommandBindingChanged));

	//    public static void SetBlackoutDates(DependencyObject d, ObservableCollection<DateTime> value)
	//    {
	//        d.SetValue(BlackoutDatesProperty, value);
	//    }

	//    public static ObservableCollection<DateTime> GetBlackoutDates(DependencyObject d)
	//    {
	//        return (ObservableCollection<DateTime>)d.GetValue(BlackoutDatesProperty);
	//    }

	//    #endregion

	//    #region Event Handlers

	//    private static void CalendarBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	//    {
	//        ObservableCollection<DateTime> BlackoutDates = sender as ObservableCollection<DateTime>;

	//        Calendar calendar = _calendars.First(c => c.Tag == BlackoutDates);

	//        if (e.Action == NotifyCollectionChangedAction.Add)
	//        {
	//            foreach (DateTime date in e.NewItems)
	//            {
	//                calendar.BlackoutDates.Add(new CalendarDateRange(date));
	//            }
	//        }
	//    }

	//    private static void DatePickerBindings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	//    {
	//        ObservableCollection<DateTime> BlackoutDates = sender as ObservableCollection<DateTime>;

	//        DatePicker datePicker = _datePickers.First(c => c.Tag == BlackoutDates);

	//        if (e.Action == NotifyCollectionChangedAction.Add)
	//        {
	//            foreach (DateTime date in e.NewItems)
	//            {
	//                datePicker.BlackoutDates.Add(new CalendarDateRange(date));
	//            }
	//        }
	//    }

	//    #endregion

	//    #region Private Methods

	//    private static void OnRegisterCommandBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	//    {
	//        Calendar calendar = sender as Calendar;
	//        if (calendar != null)
	//        {
	//            ObservableCollection<DateTime> bindings = e.NewValue as ObservableCollection<DateTime>;
	//            if (bindings != null)
	//            {
	//                if (!_calendars.Contains(calendar))
	//                {
	//                    calendar.Tag = bindings;
	//                    _calendars.Add(calendar);
	//                }

	//                calendar.BlackoutDates.Clear();
	//                foreach (DateTime date in bindings)
	//                {
	//                    calendar.BlackoutDates.Add(new CalendarDateRange(date));
	//                }
	//                bindings.CollectionChanged += CalendarBindings_CollectionChanged;
	//            }
	//        }
	//        else
	//        {
	//            DatePicker datePicker = sender as DatePicker;
	//            if (datePicker != null)
	//            {
	//                ObservableCollection<DateTime> bindings = e.NewValue as ObservableCollection<DateTime>;
	//                if (bindings != null)
	//                {
	//                    if (!_datePickers.Contains(datePicker))
	//                    {
	//                        datePicker.Tag = bindings;
	//                        _datePickers.Add(datePicker);
	//                    }

	//                    datePicker.BlackoutDates.Clear();
	//                    foreach (DateTime date in bindings)
	//                    {
	//                        datePicker.BlackoutDates.Add(new CalendarDateRange(date));
	//                    }
	//                    bindings.CollectionChanged += DatePickerBindings_CollectionChanged;
	//                }
	//            }
	//        }
	//    }

	//    #endregion
	//}
	public class DateTimePickerAttachedProperties : DependencyObject
	{

		#region BlackoutDates

		// Adds a collection of command bindings to a date picker's existing BlackoutDates collection, since the collections are immutable and can't be bound to otherwise.
		//
		// Usage: <DatePicker wpfapp1:BlackoutDates.BlackoutDates="{Binding BlackoutDates}" >

		public static DependencyProperty BlackoutDatesProperty = DependencyProperty.RegisterAttached("BlackoutDates", typeof(System.Windows.Controls.CalendarBlackoutDatesCollection), typeof(DateTimePickerAttachedProperties), new PropertyMetadata(null, OnRegisterCommandBindingChanged));

		public static void SetBlackoutDates(UIElement element, System.Windows.Controls.CalendarBlackoutDatesCollection value)
		{
			if (element != null)
				element.SetValue(BlackoutDatesProperty, value);
		}
		public static System.Windows.Controls.CalendarBlackoutDatesCollection GetBlackoutDates(UIElement element)
		{
			return (element != null ? (System.Windows.Controls.CalendarBlackoutDatesCollection)element.GetValue(BlackoutDatesProperty) : null);
		}
		private static void OnRegisterCommandBindingChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			System.Windows.Controls.DatePicker element = sender as System.Windows.Controls.DatePicker;
			if (element != null)
			{
				System.Windows.Controls.CalendarBlackoutDatesCollection bindings = e.NewValue as System.Windows.Controls.CalendarBlackoutDatesCollection;
				if (bindings != null)
				{
					element.BlackoutDates.Clear();
					foreach (var dateRange in bindings)
					{
						element.BlackoutDates.Add(dateRange);
					}
				}
			}
		}

		#endregion
	}
}
