using SpaceTradersApp.Core;

namespace SpaceTradersApp.MVVM.ViewModel;

public class SectorListItemViewModel : ViewModelBase
{
	private string? _sectorName;

	public string? SectorName
	{
		get { return _sectorName; }
		set { _sectorName = value; }
	}

}