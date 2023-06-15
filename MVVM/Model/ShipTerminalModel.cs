using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The destination or departure of a ships nav route.
/// </summary>
public class ShipTerminalModel
{
    /// <summary>
    /// The symbol of the waypoint.
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The type of waypoint.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The symbol of the system the waypoint is in.
    /// </summary>
    [JsonPropertyName("systemSymbol")]
    public string? SystemSymbol { get; set; }

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

