using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Ship cargo details.
/// </summary>
public class ShipCargoModel
{
    /// <summary>
    /// The max number of items that can be stored in the cargo hold.
    /// >= 0
    /// </summary>
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    /// <summary>
    /// The number of items currently stored in the cargo hold.
    /// >= 0
    /// </summary>
    [JsonPropertyName("units")]
    public int? Units { get; set; }

    /// <summary>
    /// The items currently in the cargo hold.
    /// </summary>
    [JsonPropertyName("inventory")]
    public List<ShipInventoryModel>? Inventory { get; set; }
}

