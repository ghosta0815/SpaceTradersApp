using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// An item currently in the cargo hold.
/// </summary>
public class ShipInventoryModel
{
    /// <summary>
    /// The unique identifier of the cargo item type.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The name of the cargo item type.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the cargo item type.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The number of units of the cargo item.
    /// >= 1
    /// </summary>
    [JsonPropertyName("units")]
    public int? Units { get; set; }
}

