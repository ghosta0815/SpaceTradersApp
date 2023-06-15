using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Modules installed in this ship.
/// </summary>
public class ShipModuleModel
{
    /// <summary>
    /// The symbol of the module.
    /// Allowed values: MODULE_MINERAL_PROCESSOR_I
    ///                 MODULE_CARGO_HOLD_I
    ///                 MODULE_CREW_QUARTERS_I
    ///                 MODULE_ENVOY_QUARTERS_I
    ///                 MODULE_PASSENGER_CABIN_I
    ///                 MODULE_MICRO_REFINERY_I
    ///                 MODULE_ORE_REFINERY_I
    ///                 MODULE_FUEL_REFINERY_I
    ///                 MODULE_SCIENCE_LAB_I
    ///                 MODULE_JUMP_DRIVE_I
    ///                 MODULE_JUMP_DRIVE_II
    ///                 MODULE_JUMP_DRIVE_III
    ///                 MODULE_WARP_DRIVE_I
    ///                 MODULE_WARP_DRIVE_II
    ///                 MODULE_WARP_DRIVE_III
    ///                 MODULE_SHIELD_GENERATOR_I
    ///                 MODULE_SHIELD_GENERATOR_II
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Modules that provide capacity, such as cargo hold or crew quarters will show this value to denote how much of a
    /// bonus the module grants.
    /// >= 0
    /// </summary>
    [JsonPropertyName("capacity")]
    public int? Capacity { get; set; }

    /// <summary>
    /// Modules that have a range will such as a sensor array show this value to denote how far can the module reach
    /// with its capabilities.
    /// >= 0
    /// </summary>
    [JsonPropertyName("range")]
    public int? Range { get; set; }

    /// <summary>
    /// Name of this module.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of this module.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The requirements for installation on a ship
    /// </summary>
    [JsonPropertyName("requirements")]
    public ShipComponentRequirementsModel? Requirements { get; set; }

}

