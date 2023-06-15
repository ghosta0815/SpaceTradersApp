using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Mount installed in this ship
/// </summary>
public class ShipMountModel
{
    /// <summary>
    /// Symbol of this mount.
    /// Allowed values: MOUNT_GAS_SIPHON_I
    ///                 MOUNT_GAS_SIPHON_II
    ///                 MOUNT_GAS_SIPHON_III
    ///                 MOUNT_SURVEYOR_I
    ///                 MOUNT_SURVEYOR_II
    ///                 MOUNT_SURVEYOR_III
    ///                 MOUNT_SENSOR_ARRAY_I
    ///                 MOUNT_SENSOR_ARRAY_II
    ///                 MOUNT_SENSOR_ARRAY_III
    ///                 MOUNT_MINING_LASER_I
    ///                 MOUNT_MINING_LASER_II
    ///                 MOUNT_MINING_LASER_III
    ///                 MOUNT_LASER_CANNON_I
    ///                 MOUNT_MISSILE_LAUNCHER_I
    ///                 MOUNT_TURRET_I
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Name of this mount.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of this mount.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Mounts that have this value, such as mining lasers, denote how powerful this mount's capabilities are.
    /// >= 0
    /// </summary>
    [JsonPropertyName("strength")]
    public int? Strength { get; set; }

    /// <summary>
    /// Mounts that have this value denote what goods can be produced from using the mount.
    /// Allowed values: QUARTZ_SAND
    ///                 SILICON_CRYSTALS
    ///                 PRECIOUS_STONES
    ///                 ICE_WATER
    ///                 AMMONIA_ICE
    ///                 IRON_ORE
    ///                 COPPER_ORE
    ///                 SILVER_ORE
    ///                 ALUMINUM_ORE
    ///                 GOLD_ORE
    ///                 PLATINUM_ORE
    ///                 DIAMONDS
    ///                 URANITE_ORE
    ///                 MERITIUM_ORE
    /// </summary>
    [JsonPropertyName("deposits")]
    public List<string>? Deposits { get; set; }

    /// <summary>
    /// The requirements for installation on a ship
    /// </summary>
    [JsonPropertyName("requirements")]
    public ShipComponentRequirementsModel? Requirements { get; set; }
}

