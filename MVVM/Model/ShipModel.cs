using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// The Model of a Ship
/// </summary>
public class ShipModel
{
    /// <summary>
    /// The globally unique identifier of the ship in the following format: [AGENT_SYMBOL]-[HEX_ID]
    /// </summary>
    [JsonPropertyName("symbol")] 
    public string? Symbol { get; set; }

    /// <summary>
    /// The public registration information of the ship
    /// </summary>
    [JsonPropertyName("registration")]
    public ShipRegistrationModel? Registration { get; set; }

    /// <summary>
    /// The navigation information of the ship.
    /// </summary>
    [JsonPropertyName("nav")]
    public ShipNavigationModel? Nav { get; set; }

    /// <summary>
    /// The ship's crew service and maintain the ship's systems and equipment.
    /// </summary>
    [JsonPropertyName("crew")]
    public ShipCrewModel? Crew { get; set; }

    /// <summary>
    /// The frame of the ship. The frame determines the number of modules and mounting points of 
    /// the ship, as well as base fuel capacity. As the condition of the frame takes more wear, 
    /// the ship will become more sluggish and less maneuverable
    /// </summary>
    [JsonPropertyName("frame")]
    public ShipFrameModel? Frame { get; set; }

    /// <summary>
    /// The reactor of the ship. The reactor is responsible for powering the ship's systems and weapons.
    /// </summary>
    [JsonPropertyName("reactor")]
    public ShipReactorModel? Reactor { get; set; }

    /// <summary>
    /// The engine determines how quickly a ship travels between waypoints.
    /// </summary>
    [JsonPropertyName("engine")]
    public ShipEngineModel? Engine { get; set; }

    /// <summary>
    /// Modules installed in this ship.
    /// </summary>
    [JsonPropertyName("modules")]
    public List<ShipModuleModel>? Modules { get; set; }

    /// <summary>
    /// Mounts installed in this ship.
    /// </summary>
    [JsonPropertyName("mounts")]
    public List<ShipMountModel>? Mounts { get; set; }

    /// <summary>
    /// Ship cargo details.
    /// </summary>
    [JsonPropertyName("cargo")]
    public ShipCargoModel? Cargo { get; set; }

    /// <summary>
    /// Details of the ship's fuel tanks including how much fuel was consumed during the last transit or action.
    /// </summary>
    [JsonPropertyName("fuel")]
    public ShipFuelModel? Fuel { get; set; }
}

