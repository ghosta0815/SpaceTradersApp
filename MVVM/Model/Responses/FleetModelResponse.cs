using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// A paginated list of all of ships under your agent's ownership.
/// </summary>
public class FleetModelResponse
{
    /// <summary>
    /// A List of available Ships
    /// </summary>
    [JsonPropertyName("data")]
    public List<ShipModel>? Data { get; set; }

    /// <summary>
    /// Pagination metadata for the Shiplist.
    /// </summary>
    [JsonPropertyName("meta")]
    public PaginationMetaData? Meta { get; set; }
}

