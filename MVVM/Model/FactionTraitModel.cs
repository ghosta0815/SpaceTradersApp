using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// A class that represents a trait of a faction
/// </summary>
public class FactionTraitModel
{
    /// <summary>
    /// The unique identifier of the trait.
    /// Allowed value: BUREAUCRATIC
    ///                SECRETIVE
    ///                CAPITALISTIC
    ///                INDUSTRIOUS
    ///                PEACEFUL
    ///                DISTRUSTFUL
    ///                WELCOMING
    ///                SMUGGLERS
    ///                SCAVENGERS
    ///                REBELLIOUS
    ///                EXILES
    ///                PIRATES
    ///                RAIDERS
    ///                CLAN
    ///                GUILD
    ///                DOMINION
    ///                FRINGE
    ///                FORSAKEN
    ///                ISOLATED
    ///                LOCALIZED
    ///                ESTABLISHED
    ///                NOTABLE
    ///                DOMINANT
    ///                INESCAPABLE
    ///                INNOVATIVE
    ///                BOLD
    ///                VISIONARY
    ///                CURIOUS
    ///                DARING
    ///                EXPLORATORY
    ///                RESOURCEFUL
    ///                FLEXIBLE
    ///                COOPERATIVE
    ///                UNITED
    ///                STRATEGIC
    ///                INTELLIGENT
    ///                RESEARCH_FOCUSED
    ///                COLLABORATIVE
    ///                PROGRESSIVE
    ///                MILITARISTIC
    ///                TECHNOLOGICALLY_ADVANCED
    ///                AGGRESSIVE
    ///                IMPERIALISTIC
    ///                TREASURE_HUNTERS
    ///                DEXTEROUS
    ///                UNPREDICTABLE
    ///                BRUTAL
    ///                FLEETING
    ///                ADAPTABLE
    ///                SELF_SUFFICIENT
    ///                DEFENSIVE
    ///                PROUD
    ///                DIVERSE
    ///                INDEPENDENT
    ///                SELF_INTERESTED
    ///                FRAGMENTED
    ///                COMMERCIAL
    ///                FREE_MARKETS
    ///                ENTREPRENEURIAL
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The name of the trait.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of the trait.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}


