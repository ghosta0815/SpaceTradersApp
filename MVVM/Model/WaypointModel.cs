using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class that represents a waypoint in a system
/// </summary>
public class WaypointModel
{
    /// <summary>
    /// The symbol of the waypoint.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The type of waypoint.
    /// Allowed values: PLANET
    ///                 GAS_GIANT
    ///                 MOON
    ///                 ORBITAL_STATION
    ///                 JUMP_GATE
    ///                 ASTEROID_FIELD
    ///                 NEBULA
    ///                 DEBRIS_FIELD
    ///                 GRAVITY_WELL
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Position in the universe in the x axis.
    /// </summary>
    [JsonPropertyName("x")]
    public int? X { get; set; }

    /// <summary>
    /// Position in the universe in the y axis.
    /// </summary>
    [JsonPropertyName("y")]
    public int? Y { get; set; }
}


