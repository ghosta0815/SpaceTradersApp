using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class representing a single system
/// </summary>
public class SystemModel
{
    /// <summary>
    /// The symbol of the system.
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }


    /// <summary>
    /// The symbol of the sector.
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("sectorSymbol")]
    public string? SectorSymbol { get; set; }

    /// <summary>
    /// The type of waypoint.
    /// Allowed values: NEUTRON_STAR
    ///                 RED_STAR
    ///                 ORANGE_STAR
    ///                 BLUE_STAR
    ///                 YOUNG_STAR
    ///                 WHITE_DWARF
    ///                 BLACK_HOLE
    ///                 HYPERGIANT
    ///                 NEBULA
    ///                 UNSTABLE
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

    /// <summary>
    /// Waypoints in this system.
    /// </summary>
    [JsonPropertyName("waypoints")]
    public List<WaypointModel>? Waypoints { get; set; }

    /// <summary>
    /// Factions that control this system.
    /// </summary>
    [JsonPropertyName("factions")]
    public List<SystemFactionModel>? Factions { get; set; }
}


