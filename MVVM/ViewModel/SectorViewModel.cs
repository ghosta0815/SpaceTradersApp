using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

/// <summary>
/// A class on displaying the sectors
/// </summary>
public class SectorViewModel
{
    #region public members
    /// <summary>
    /// The list of available ships
    /// </summary>
    public ObservableCollection<SectorListItemViewModel>? SectorListItemVMs { get; set; } = new ObservableCollection<SectorListItemViewModel>();

    public ObservableCollection<WaypointListItemViewModel>? WaypointListItemVMs { get; set; } = new ObservableCollection<WaypointListItemViewModel>()
    {
        new WaypointListItemViewModel()
        {
            Name = "Best planet Ever",
            X = 100,
            Y = 200
        }
    };
    #endregion

    #region async methods
    /// <summary>
    /// Displays the ships of the agent
    /// </summary>
    /// <param name="listSystemsResponse">the reponse model containing the ships</param>
    internal void DisplaySectorList(ListSystemsResponse? listSystemsResponse)
    {
        SectorListItemVMs!.Clear();

        if (listSystemsResponse == null) { return; }
        foreach(SystemModel? system in listSystemsResponse!.Data!)
        {
            string factionList = "";
            foreach(var systemFactionModel in system.Factions!)
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
    }
    #endregion
}
