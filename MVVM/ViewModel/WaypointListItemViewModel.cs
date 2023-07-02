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
        #region private Members
        private int? _x;
        private int? _y;
        private string? _name;
        private string? _wayPointType;
        #endregion

        #region public Members
		/// <summary>
		/// The X Position of the Waypoint
		/// </summary>
        public int? X
		{
			get { return _x; }
			set { _x = value; }
		}

		/// <summary>
		/// The Y Position of the Waypoint
		/// </summary>
		public int? Y
		{
			get { return _y; }
			set { _y = value; }
		}


		/// <summary>
		/// The Name of the waypoint
		/// </summary>
		public string? Name
		{
			get { return _name; }
			set { _name = value; }
		}

		/// <summary>
		/// The Type of the Waypoint
		/// </summary>
		public string? WayPointType
		{
			get { return _wayPointType; }
			set { _wayPointType = value; }
		}
		#endregion
	}
}
