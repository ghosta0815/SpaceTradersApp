using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The frame of the ship. The frame determines the number of modules and mounting points of the ship, as well as base 
/// fuel capacity. As the condition of the frame takes more wear, the ship will become more sluggish and less
/// maneuverable.
/// </summary>
public class ShipFrameModel
{
    /// <summary>
    /// Symbol of the frame.
    /// Allowed values: FRAME_PROBE
    ///                 FRAME_DRONE
    ///                 FRAME_INTERCEPTOR
    ///                 FRAME_RACER
    ///                 FRAME_FIGHTER
    ///                 FRAME_FRIGATE
    ///                 FRAME_SHUTTLE
    ///                 FRAME_EXPLORER
    ///                 FRAME_MINER
    ///                 FRAME_LIGHT_FREIGHTER
    ///                 FRAME_HEAVY_FREIGHTER
    ///                 FRAME_TRANSPORT
    ///                 FRAME_DESTROYER
    ///                 FRAME_CRUISER
    ///                 FRAME_CARRIER
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// Name of the frame.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of the frame.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new
    /// >= 0
    /// <= 100
    /// </summary>
    [JsonPropertyName("condition")]
    public int Condition { get; set; }

    /// <summary>
    /// The amount of slots that can be dedicated to modules installed in the ship. Each installed module take up a 
    /// number of slots, and once there are no more slots, no new modules can be installed.
    /// >= 0
    /// </summary>
    [JsonPropertyName("moduleSlots")]
    public int ModuleSlots { get; set; }

    /// <summary>
    /// The amount of slots that can be dedicated to mounts installed in the ship. Each installed mount takes up a 
    /// number of points, and once there are no more points remaining, no new mounts can be installed.
    /// >= 0
    /// </summary>
    [JsonPropertyName("mountingPoints")]
    public int MountingPoints { get; set; }

    /// <summary>
    /// The maximum amount of fuel that can be stored in this ship. When refueling, the ship will be refueled to this
    /// amount.
    /// >= 0
    /// </summary>
    [JsonPropertyName("fuelCapacity")]
    public int FuelCapacity { get; set; }

    /// <summary>
    /// The requirements for installation on a ship
    /// </summary>
    [JsonPropertyName("requirements")]
    public ShipComponentRequirementsModel? Requirements { get; set; }
}

