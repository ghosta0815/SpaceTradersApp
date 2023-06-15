using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Details of the ship's fuel tanks including how much fuel was consumed during the last transit or action.
/// </summary>
public class ShipFuelModel
{
    /// <summary>
    /// The current amount of fuel in the ship's tanks.
    /// >= 0
    /// </summary>
    [JsonPropertyName("current")]
    public int? Current { get; set; }

    /// <summary>
    /// The maximum amount of fuel the ship's tanks can hold.
    /// >= 0
    /// </summary>
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    /// <summary>
    /// An object that only shows up when an action has consumed fuel in the process. Shows the fuel consumption data.
    /// </summary>
    [JsonPropertyName("consumed")]
    public ShipFuelConsumptionModel? Consumed { get; set; }
}

