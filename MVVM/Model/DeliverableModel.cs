using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class representing the cargot that needs to be delivered to fulfill a contract
/// </summary>
public class DeliverableModel
{
    /// <summary>
    /// The symbol of the trade good to deliver.
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("tradeSymbol")]
    public string? TradeSymbol { get; set; }

    /// <summary>
    /// The destination where goods need to be delivered.
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("destinationSymbol")]
    public string? DestinationSymbol { get; set; }

    /// <summary>
    /// The number of units that need to be delivered on this contract.
    /// </summary>
    [JsonPropertyName("unitsRequired")]
    public int? UnitsRequired { get; set; }

    /// <summary>
    /// The number of units fulfilled on this contract.
    /// </summary>
    [JsonPropertyName("unitsFulfilled")]
    public int? UnitsFulfilled { get; set; }
}


