using System;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Model representing a contract
/// </summary>
public class ContractModel
{
    /// <summary>
    /// ID of the contract.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The symbol of the faction that this contract is for.
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("factionSymbol")]
    public string? FactionSymbol { get; set; }

    /// <summary>
    /// Type of contract.
    /// Allowed values: PROCUREMENT
    ///                 TRANSPORT
    ///                 SHUTTLE
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The terms to fulfill the contract.
    /// </summary>
    [JsonPropertyName("terms")]
    public ContractTermsModel? Terms { get; set; }

    /// <summary>
    /// Whether the contract has been accepted by the agent
    /// Default: false
    /// </summary>
    [JsonPropertyName("accepted")]
    public bool? Accepted { get; set; }

    /// <summary>
    /// Whether the contract has been fulfilled
    /// Default: false
    /// </summary>
    [JsonPropertyName("fulfilled")]
    public bool? Fulfilled { get; set; }

    /// <summary>
    /// Deprecated in favor of deadlineToAccept
    /// </summary>
    [JsonPropertyName("expiration")]
    public DateTime? Expiration { get; set; }

    /// <summary>
    /// The time at which the contract is no longer available to be accepted
    /// </summary>
    [JsonPropertyName("deadlineToAccept")]
    public DateTime? DeadlineToAccept { get; set; }
}


