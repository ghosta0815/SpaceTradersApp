using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The reactor of the ship. The reactor is responsible for powering the ship's systems and weapons.
/// </summary>
public class ShipReactorModel
{
    /// <summary>
    /// Symbol of the reactor.
    /// Allowed values: REACTOR_SOLAR_I
    ///                 REACTOR_FUSION_I
    ///                 REACTOR_FISSION_I
    ///                 REACTOR_CHEMICAL_I
    ///                 REACTOR_ANTIMATTER_I
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Name of the reactor.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of the reactor.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new.
    /// </summary>
    [JsonPropertyName("condition")]
    public int Condition { get; set; }

    /// <summary>
    /// The amount of power provided by this reactor. The more power a reactor provides to the ship, the lower the
    /// cooldown it gets when using a module or mount that taxes the ship's power.
    /// >= 1
    /// </summary>
    [JsonPropertyName("powerOutput")]
    public int PowerOutput { get; set; }

    /// <summary>
    /// The requirements for installation on a ship
    /// </summary>
    [JsonPropertyName("requirements")]
    public ShipComponentRequirementsModel? Requirements { get; set; }
}

