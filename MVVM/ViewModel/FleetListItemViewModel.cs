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
    #endregion

    #region constructors
	/// <summary>
	/// The default constructor
	/// </summary>
	/// <param name="shipname">The name of the ship</param>
	/// <param name="role">The role of the ship</param>
	/// <param name="fuelLevel">The current and max fuel level current/Max</param>
	/// <param name="status">The status of the ship</param>
	public FleetListItemViewModel(string shipname, string role, string fuelLevel, string status)
    {
		Role = role;
		ShipName = shipname;
		FuelLevel = fuelLevel;
		Status = status;
    }
	#endregion
}
