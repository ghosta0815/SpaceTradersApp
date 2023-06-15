using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// Meta details for pagination.
/// </summary>
public class PaginationMetaData
{
    /// <summary>
    /// Shows the total amount of items of this kind that exist.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// A page denotes an amount of items, offset from the first item. Each page holds an amount of items equal to the limit.
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// The amount of items in each page. Limits how many items can be fetched at once.
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }
}

