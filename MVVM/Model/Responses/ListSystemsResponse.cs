using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// GET https://api.spacetraders.io/v2/systems
/// </summary>
public class ListSystemsResponse
{
    /// <summary>
    /// The List containing several systems
    /// </summary>
    [JsonPropertyName("data")]
    public List<SystemModel>? Data { get; set; }

    /// <summary>
    /// The pagination Data
    /// </summary>
    [JsonPropertyName("meta")]
    public PaginationMetaData? Meta { get; set; }
}


