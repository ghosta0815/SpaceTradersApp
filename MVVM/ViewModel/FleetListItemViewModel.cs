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

    public FleetListItemViewModel(string shipname, string role)
    {
		Role = role;
		ShipName = shipname;
    }

}
