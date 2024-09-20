using GalaSoft.MvvmLight.Command;
using System;
using System.Data;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
//using Xceed.Wpf.DataGrid;

namespace WpfApp1
{
	public partial class MyDataTable
	{
		private MyDataTableVM vm;
		private DataTable dataTable;

		public MyDataTable()
		{
			Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP70DM4PTRAU7DJ32A";
				InitializeComponent();
			dataTable = new DataTable();
			var view = dataTable.AsDataView();
			var src = new Xceed.Wpf.DataGrid.DataGridCollectionViewSource();
			src.Source = view;
			src.AutoFilterMode = Xceed.Wpf.DataGrid.AutoFilterMode.And;
			var binding = new Binding();
			binding.Mode = BindingMode.OneWay;
			binding.Source = src;
			//_mainGrid.SetBinding(Xceed.Wpf.DataGrid.DataGridControl.ItemsSourceProperty, binding);

			DataContext = vm = new MyDataTableVM();
			Loaded += MyDataTable_Loaded;
		}

		private void MyDataTable_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			//dtPicker.BlackoutDates.Add(new System.Windows.Controls.CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1)));
			//dtPicker.BlackoutDates.Add(new System.Windows.Controls.CalendarDateRange(DateTime.Today.AddDays(3)));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("Time", typeof(DateTime));
			for (var i = 1; i < 4; i++)
			{
				dataTable.Rows.Add(new object[] { $"Name_{i}", DateTime.Today.AddDays(i).AddSeconds(-1) });
			}
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			var sb = new StringBuilder();
			foreach (DataRow row in dataTable.Rows)
			{
				for (int i = 0; i < row.ItemArray.Length; i++)
				{
					var col = row.ItemArray[i];
					if (i == 1)
					{
						var dateTime = (DateTime)col;
						sb.Append($"{dateTime:yyyyMMdd HH:mm:ss}");
					}
					else
						sb.Append($"{col},");
				}
				sb.Append("\r\n");
			}
			//myVals.Text = sb.ToString();
		}
	}
}
