using SpaceTradersApp.Core;

namespace SpaceTradersApp.MVVM.ViewModel;

/// <summary>
/// The Listitems in the Sector view
/// </summary>
public class SectorListItemViewModel : ViewModelBase
{
    #region private Members
    private string? _sectorName;
    private string? _sectorType;
    private int? _wayPoints;
    private string? _factions;
    #endregion

    #region public Members
	/// <summary>
	/// The name of the Sector
	/// </summary>
    public string? SectorName
	{
		get { return _sectorName; }
		set { _sectorName = value; }
	}

	/// <summary>
	/// The Type of main solar body
	/// </summary>
	public string? SectorType
	{
		get { return _sectorType; }
		set { _sectorType = value; }
	}

	/// <summary>
	/// The amount of waypoints in this sector
	/// </summary>
	public int? WayPoints
	{
		get { return _wayPoints; }
		set { _wayPoints = value; }
	}

	/// <summary>
	/// The factions controlling the sector
	/// </summary>
	public string? Factions
	{
		get { return _factions; }
		set { _factions = value; }
	}
	#endregion
}