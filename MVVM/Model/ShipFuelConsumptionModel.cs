using System;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Shows the fuel consumption data.
/// </summary>
public class ShipFuelConsumptionModel
{
    /// <summary>
    /// The amount of fuel consumed by the most recent transit or action.
    /// >= 0
    /// </summary>
    [JsonPropertyName("amount")]
    public int? Amount { get; set; }

    /// <summary>
    /// The time at which the fuel was consumed.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }
}

