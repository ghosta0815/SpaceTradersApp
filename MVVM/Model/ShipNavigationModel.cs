using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The navigation information of the ship.
/// </summary>
public class ShipNavigationModel
{
    /// <summary>
    /// The system symbol of the ship's current location.
    /// </summary>
    [JsonPropertyName("systemSymbol")]
    public string? SystemSymbol { get; set; }

    /// <summary>
    /// The waypoint symbol of the ship's current location, or if the ship is in-transit, the waypoint symbol of the ship's destination.
    /// </summary>
    [JsonPropertyName("waypointSymbol")]
    public string? WaypointSymbol { get; set; }

    /// <summary>
    /// The routing information for the ship's most recent transit or current location.
    /// </summary>
    [JsonPropertyName("route")]
    public ShipRouteModel? Route { get; set; }

    /// <summary>
    /// The current status of the ship
    /// Allowed values: IN_TRANSIT
    ///                 IN_ORBIT
    ///                 DOCKED
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// The ship's set speed when traveling between waypoints or systems.
    /// Allowed values: DRIFT
    ///                 STEALTH
    ///                 CRUISE
    ///                 BURN
    /// Default: CRUISE
    /// </summary>
    [JsonPropertyName("flightMode")]
    public string? FlightMode { get; set; }
}

