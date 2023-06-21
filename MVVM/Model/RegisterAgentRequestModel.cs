using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The request for creating a new Agent
/// </summary>
class RegisterAgentRequestModel
{
    /// <summary>
    /// The name of the faction the agent shall be created on
    /// >= 1 characters
    /// Allowed values: COSMIC
    ///                 VOID
    ///                 GALACTIC
    ///                 QUANTUM
    ///                 DOMINION
    ///                 ASTRO
    ///                 CORSAIRS
    ///                 OBSIDIAN
    ///                 AEGIS
    ///                 UNITED
    ///                 SOLITARY
    ///                 COBALT
    ///                 OMEGA
    ///                 ECHO
    ///                 LORDS
    ///                 CULT
    ///                 ANCIENTS
    ///                 SHADOW
    ///                 ETHEREAL
    /// </summary>
    [JsonPropertyName("faction")]
    public string? Faction { get; set; }

    /// <summary>
    /// The identifier of the agent
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Optional: The eMail Address of the creator
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
