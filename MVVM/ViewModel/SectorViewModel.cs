using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

/// <summary>
/// A class on displaying the sectors
/// </summary>
public class SectorViewModel : ViewModelBase
{
    private SectorListItemViewModel? _selectedSector;

    #region public members
    /// <summary>
    /// The list of available Sectors
    /// </summary>
    public ObservableCollection<SectorListItemViewModel>? SectorListItemVMs { get; set; } = new ObservableCollection<SectorListItemViewModel>();

    public ObservableCollection<WaypointListItemViewModel>? WaypointListItemVMs { get; set; } = new ObservableCollection<WaypointListItemViewModel>();

    public SectorListItemViewModel? SelectedSector
    {
        get { return _selectedSector; }
        set
        {
            _selectedSector = value;
            OnPropertyChanged(nameof(SelectedSector));
        }
    }

    #endregion

    #region commands
    public IAsyncCommand SelectedItemChangedCommand { get; set; }
    #endregion

    public SectorViewModel()
    {
        SelectedItemChangedCommand = new AsyncCommand(async () =>
        {
            await DisplaySector();
        });
    }

    /// <summary>
    /// Displays the ships of the agent
    /// </summary>
    /// <param name="listSystemsResponse">the reponse model containing the ships</param>
    internal void DisplaySectorList(ListSystemsResponse? listSystemsResponse)
    {
        SectorListItemVMs!.Clear();

        if (listSystemsResponse == null) { return; }
        foreach (SystemModel? system in listSystemsResponse!.Data!)
        {
            string factionList = "";
            foreach (var systemFactionModel in system.Factions!)
            {
                factionList += $"|{systemFactionModel.Symbol}";
            }
            SectorListItemViewModel sectorListItem = new SectorListItemViewModel()
            {
                SectorName = system.Symbol,
                SectorType = system.Type,
                Factions = factionList,
                WayPoints = system.Waypoints!.Count
            };
            SectorListItemVMs!.Add(sectorListItem);
        }
        SelectedSector = SectorListItemVMs[0];
    }

    #region async methods
    /// <summary>
    /// Disploys the waypoints of a system
    /// </summary>
    /// <param name="system"></param>
    internal async Task DisplaySector()
    {
        WaypointListItemVMs!.Clear();
        var system = await IoCContainer.SpaceTradersAPI.getWaypointsAsync(SelectedSector!.SectorName!);
        if (system == null) { return; }
        foreach(WaypointModel waypoint in system.Waypoints!)
        {
            var waypointVM = new WaypointListItemViewModel()
            {
                Name = waypoint.Symbol,
                X = waypoint.X,
                Y = waypoint.Y,
                WayPointType = waypoint.Type
            };
            WaypointListItemVMs.Add(waypointVM);
        }
    }
    #endregion
}
