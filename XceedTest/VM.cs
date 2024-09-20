using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
	public class VM
	{
		public ObservableCollection<Data> Left { get; private set; }
		public ObservableCollection<Data> Right { get; private set; }

		public VM()
		{
			Left = new ObservableCollection<Data>();
			Right = new ObservableCollection<Data>();
			var llast = 0;
			var rlast = 0;
			for (int i = 1; i < 5; i++)
			{
				var l = new Data { Age = i + 1000, Id = $"L_{i}", Name = $"L_N_{i}" };

				llast += l.Age;
				l.ToolTip += llast;
				Left.Add(l);

				var r = new Data { Age = i + 2000, Id = $"R_{i}", Name = $"R_N_{i}" };
				rlast += r.Age;
				r.ToolTip += rlast;
				Right.Add(r);
			}
		}
	}
}
