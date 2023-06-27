using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The information of a full account
/// </summary>
public class AccountModel
{
    /// <summary>
    /// Agent Details
    /// </summary>
    [JsonPropertyName("agent")]
    public AgentModel? Agent { get; set; }

    /// <summary>
    /// Contract Details of the initial contract
    /// </summary>
    [JsonPropertyName("contract")]
    public ContractModel? Contract { get; set; }

    /// <summary>
    /// Faction Details of the agent faction
    /// </summary>
    [JsonPropertyName("faction")]
    public FactionModel? Faction { get; set; }

    /// <summary>
    /// Details of the agent ship
    /// </summary>
    [JsonPropertyName("ship")]
    public ShipModel? Ship { get; set; }

    /// <summary>
    /// A Bearer token for accessing secured API endpoints.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
