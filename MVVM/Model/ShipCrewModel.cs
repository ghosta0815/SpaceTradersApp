using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The ship's crew service and maintain the ship's systems and equipment.
/// </summary>
public class ShipCrewModel
{

    /// <summary>
    /// The current number of crew members on the ship.
    /// </summary>
    [JsonPropertyName("current")]
    public int Current { get; set; }

    /// <summary>
    /// The minimum number of crew members required to maintain the ship.
    /// </summary>
    [JsonPropertyName("required")]
    public int Required { get; set; }

    /// <summary>
    /// The maximum number of crew members the ship can support.
    /// </summary>
    [JsonPropertyName("capacity")]
    public int Capacity { get; set; }

    /// <summary>
    /// The rotation of crew shifts. A stricter shift improves the ship's performance. 
    /// Allowed values: STRICT
    ///                 RELAXED
    /// Default: STRICT
    /// 
    [JsonPropertyName("rotation")]
    public string? Rotation { get; set; }

    /// <summary>
    /// A rough measure of the crew's morale. A higher morale means the crew is happier and more productive.
    /// A lower morale means the ship is more prone to accidents.
    /// >= 0
    /// <= 100
    /// </summary>
    [JsonPropertyName("morale")]
    public int Morale { get; set; }

    /// <summary>
    /// The amount of credits per crew member paid per hour. Wages are paid when a ship docks at a civilized waypoint. 
    /// >= 0
    /// </summary>
    [JsonPropertyName("wages")]
    public int Wages { get; set; }
}

