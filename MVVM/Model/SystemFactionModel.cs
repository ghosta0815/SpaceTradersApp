using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Class representing the controller of a system
/// </summary>
public class SystemFactionModel
{
    /// <summary>
    /// The Symbol of the controlling faction
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
}


