using SpaceTradersApp.Core;

namespace SpaceTradersApp.MVVM.ViewModel;

public class FleetListItemViewModel : ViewModelBase
{

	private string? _role;

	public string? Role
	{
		get { return _role; }
		set { _role = value; OnPropertyChanged(nameof(Role)); }
	}

	private string? _shipName;

	public string? ShipName
	{
		get { return _shipName; }
		set { _shipName = value; OnPropertyChanged(nameof(ShipName)); }


	}

	private string? _fuel;

	public string? FuelLevel
	{
		get { return _fuel; }
		set { _fuel = value; OnPropertyChanged(nameof(FuelLevel)); }
	}

	private string? _status;

	public string? Status
	{
		get { return _status; }
		set { _status = value; OnPropertyChanged(nameof(Status)); }
	}


	public FleetListItemViewModel(string shipname, string role, string fuelLevel, string status)
    {
		Role = role;
		ShipName = shipname;
		FuelLevel = fuelLevel;
		Status = status;
    }

}
