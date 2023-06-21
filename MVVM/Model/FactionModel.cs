using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// This class represents the faction Details
/// </summary>
public class FactionModel
{
    /// <summary>
    /// The faction symbol that identifies a faction
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
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The name of this faction
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// This one describes the faction for a human
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// This is the waypoint location of the headquarters
    /// </summary>
    [JsonPropertyName("headquarters")]
    public string? Headquarters { get; set; }

    /// <summary>
    /// List of traits that define this faction.
    /// </summary>
    [JsonPropertyName("traits")]
    public List<FactionTraitModel>? Traits { get; set; }

    /// <summary>
    /// Whether or not the faction is currently recruiting new agents.
    /// </summary>
    [JsonPropertyName("isRecruiting")]
    public bool? IsRecruiting { get; set; }
}


