using System;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The routing information for the ship's most recent transit or current location.
/// </summary>
public class ShipRouteModel
{
    /// <summary>
    /// The destinationof a ships nav route.
    /// </summary>
    [JsonPropertyName("destination")]
    public ShipTerminalModel? Destination { get; set; }

    /// <summary>
    /// The departure of a ships nav route.
    /// </summary>
    [JsonPropertyName("departure")]
    public ShipTerminalModel? Departure { get; set; }

    /// <summary>
    /// The date time of the ship's departure.
    /// </summary>
    [JsonPropertyName("departureTime")]
    public DateTime? DepartureTime { get; set; }

    /// <summary>
    /// The date time of the ship's arrival. If the ship is in-transit, this is the expected time of arrival.
    /// </summary>
    [JsonPropertyName("arrival")]
    public DateTime? Arrival { get; set; }
}

