using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class representing the payment details of a contract
/// </summary>
public class PaymentModel
{
    /// <summary>
    /// The amount of credits received up front for accepting the contract.
    /// </summary>
    [JsonPropertyName("onAccepted")]
    public int? OnAccepted { get; set; }

    /// <summary>
    /// The amount of credits received when the contract is fulfilled.
    /// </summary>
    [JsonPropertyName("onFulfilled")]
    public int? OnFulfilled { get; set; }
}


