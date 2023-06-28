using SpaceTradersApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel
{
    public class WaypointListItemViewModel: ViewModelBase
    {
		private int? _x;

		public int? X
		{
			get { return _x; }
			set { _x = value; }
		}

		private int? _y;

		public int? Y
		{
			get { return _y; }
			set { _y = value; }
		}

		private string? _name;

		public string? Name
		{
			get { return _name; }
			set { _name = value; }
		}
	}
}
