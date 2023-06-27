using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// GET https://api.spacetraders.io/v2/systems/{systemSymbol}
/// </summary>
public class ListSystemResponse
{
    /// <summary>
    /// Data containing a single System
    /// </summary>
    [JsonPropertyName("data")]
    public SystemModel? Data { get; set; }
}


