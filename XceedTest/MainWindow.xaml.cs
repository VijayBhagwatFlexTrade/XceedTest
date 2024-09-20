using System.Diagnostics;

namespace WpfApp1
{
	public partial class MainWindow
	{
		private VM vm;
		public MainWindow()
		{
			Xceed.Wpf.DataGrid.Licenser.LicenseKey = "DGP70DM4PTRAU7DJ32A";
			InitializeComponent();
			DataContext = vm = new VM();
		}

		private void DataGridControl_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Trace.WriteLine($"MouseDown {e}");
		}

		private void DataGridControl_SelectionChanging(object sender, Xceed.Wpf.DataGrid.DataGridSelectionChangingEventArgs e)
		{
			if(e.SelectionInfos.Count > 1)
			Trace.WriteLine($"SelectionChanging {e}");
		}

		private void DataGridControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//e.
		}
	}
}
