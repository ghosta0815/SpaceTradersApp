using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

/// <summary>
/// A class on displaying the fleet view
/// </summary>
public class FleetViewModel
{
    #region public members
    /// <summary>
    /// The list of available ships
    /// </summary>
    public ObservableCollection<FleetListItemViewModel>? ShipListItemVMs { get; set; } = new ObservableCollection<FleetListItemViewModel>();
    #endregion

    #region async methods
    /// <summary>
    /// Displays the ships of the agent
    /// </summary>
    /// <param name="shipModelResponse">the reponse model containing the ships</param>
    internal void DisplayShipList(MyShipsModelResponse? shipModelResponse)
    {
        ShipListItemVMs!.Clear();

        if (shipModelResponse == null) { return; }
        foreach(ShipModel? ship in shipModelResponse!.Data!)
        {
            FleetListItemViewModel shipListItem = new FleetListItemViewModel()
            {
                ShipName = ship.Registration!.Name!,
                Role = ship.Registration.Role!,
                FuelLevel = $"{ship.Fuel!.Current}/{ship.Fuel.Capacity}",
                Status = ship.Nav!.Status!,
                System = ship.Nav.SystemSymbol,
                WayPoint = ship.Nav.WaypointSymbol
            };
            ShipListItemVMs!.Add(shipListItem);
        }
    }
    #endregion
}
