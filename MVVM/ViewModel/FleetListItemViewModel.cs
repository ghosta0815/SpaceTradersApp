using SpaceTradersApp.Core;

namespace SpaceTradersApp.MVVM.ViewModel;

/// <summary>
/// A class representing a single ship in the fleet view
/// </summary>
public class FleetListItemViewModel : ViewModelBase
{
    #region private Members
    private string? _role;

    private string? _shipName;

    private string? _fuel;

    private string? _status;

	private string? _system;

	private string? _wayPoint;
	#endregion

	#region Public Members
	/// <summary>
	/// The role of the ship, e.g. explorer, freighter
	/// </summary>
	public string? Role
	{
		get { return _role; }
		set { _role = value; OnPropertyChanged(nameof(Role)); }
	}

	/// <summary>
	/// The name of the ship
	/// </summary>
	public string? ShipName
	{
		get { return _shipName; }
		set { _shipName = value; OnPropertyChanged(nameof(ShipName)); }


	}

	/// <summary>
	/// The fuel level of the ship current/max
	/// </summary>
	public string? FuelLevel
	{
		get { return _fuel; }
		set { _fuel = value; OnPropertyChanged(nameof(FuelLevel)); }
	}

	/// <summary>
	/// The ship status, e.g. transit, docked
	/// </summary>
	public string? Status
	{
		get { return _status; }
		set { _status = value; OnPropertyChanged(nameof(Status)); }
	}

    /// <summary>
    /// The System the ship is currently in
    /// </summary>
    public string? System
    {
        get { return _system; }
        set { _system = value; }
    }

    /// <summary>
    /// The waypoint symbol of the ship's current location, or if the ship is in-transit, 
	/// the waypoint symbol of the ship's destination.
    /// </summary>
    public string? WayPoint
    {
        get { return _wayPoint; }
        set { _wayPoint = value; }
    }
    #endregion

    #region constructors
    /// <summary>
    /// The default constructor
    /// </summary>
    public FleetListItemViewModel()
    {
    }
	#endregion
}
