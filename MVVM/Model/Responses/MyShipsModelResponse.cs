using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// GET https://api.spacetraders.io/v2/my/ships
/// </summary>
public class MyShipsModelResponse
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

