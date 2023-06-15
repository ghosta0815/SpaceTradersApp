using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The requirements for installation on a ship
/// </summary>
public class ShipComponentRequirementsModel
{
    /// <summary>
    /// The amount of power required from the reactor.
    /// </summary>
    [JsonPropertyName("power")]
    public int Power { get; set; }

    /// <summary>
    /// The number of crew required for operation.
    /// </summary>
    [JsonPropertyName("crew")]
    public int Crew { get; set; }

    /// <summary>
    /// The number of module slots required for installation.
    /// </summary>
    [JsonPropertyName("slots")]
    public int Slots { get; set; }
}

