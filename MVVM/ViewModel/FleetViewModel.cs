using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpaceTradersApp.MVVM.ViewModel;

public class FleetViewModel
{
    public ObservableCollection<FleetListItemViewModel>? ShipListItemVMs { get; set; } = new ObservableCollection<FleetListItemViewModel>();

    internal void DisplayShipListAsync(FleetModelResponse? shipModelResponse)
    {
        ShipListItemVMs!.Clear();

        if (shipModelResponse == null) { return; }
        foreach(ShipModel? ship in shipModelResponse!.Data!)
        {
            FleetListItemViewModel shipListItem = new FleetListItemViewModel(ship.Registration!.Name!, ship.Registration.Role!);
            ShipListItemVMs!.Add(shipListItem);
        }
    }
}
