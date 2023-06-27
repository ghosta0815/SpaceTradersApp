using SpaceTradersApp.Core;
using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.ObjectModel;
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
            SectorListItemViewModel sectorListItem = new SectorListItemViewModel()
            {
                SectorName = system.Symbol
            };
            SectorListItemVMs!.Add(sectorListItem);
        }
    }
    #endregion
}
