using GalaSoft.MvvmLight;

namespace WpfApp1
{
	public class Data : ObservableObject
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public int ToolTip { get; set; }
	}
}
