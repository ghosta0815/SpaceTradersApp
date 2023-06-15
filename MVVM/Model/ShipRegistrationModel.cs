using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The public registration information of the ship
/// </summary>
public class ShipRegistrationModel
{
    /// <summary>
    /// The agent's registered name of the ship
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The symbol of the faction the ship is registered with
    /// >= 1 characters
    /// </summary>
    [JsonPropertyName("factionSymbol")]
    public string? FactionSymbol { get; set; }

    /// <summary>
    /// The registered role of the ship
    /// Allowed values: FABRICATOR
    ///                 HARVESTER
    ///                 HAULER
    ///                 INTERCEPTOR
    ///                 EXCAVATOR
    ///                 TRANSPORT
    ///                 REPAIR
    ///                 SURVEYOR
    ///                 COMMAND
    ///                 CARRIER
    ///                 PATROL
    ///                 SATELLITE
    ///                 EXPLORER
    ///                 REFINERY
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }
}

