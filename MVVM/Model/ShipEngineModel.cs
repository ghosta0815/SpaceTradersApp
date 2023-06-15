using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The engine determines how quickly a ship travels between waypoints.
/// </summary>
public class ShipEngineModel
{
    /// <summary>
    /// The symbol of the engine.
    /// Allowed values: ENGINE_IMPULSE_DRIVE_I
    ///                 ENGINE_ION_DRIVE_I
    ///                 ENGINE_ION_DRIVE_II
    ///                 ENGINE_HYPER_DRIVE_I
    /// </summary>
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }

    /// <summary>
    /// The name of the engine.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the engine.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Condition is a range of 0 to 100 where 0 is completely worn out and 100 is brand new.
    /// >= 0
    /// <= 100
    /// </summary>
    [JsonPropertyName("condition")]
    public int Condition { get; set; }

    /// <summary>
    /// The speed stat of this engine. The higher the speed, the faster a ship can travel from one point to another.
    /// Reduces the time of arrival when navigating the ship.
    /// >= 1
    /// </summary>
    [JsonPropertyName("speed")]
    public int Speed { get; set; }

    /// <summary>
    /// The requirements for installation on a ship
    /// </summary>
    [JsonPropertyName("requirements")]
    public ShipComponentRequirementsModel? Requirements { get; set; }
}

