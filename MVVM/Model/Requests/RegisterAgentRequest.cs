using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class that requests a new User agent
/// </summary>
public class RegisterAgentRequest
{
    /// <summary>
    /// The name of the faction the agent starts with
    /// </summary>
    [JsonPropertyName("faction")]
    public string? Faction { get; set; }

    /// <summary>
    /// The symbol of the user
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The email adress of the player
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; } = null;
}

