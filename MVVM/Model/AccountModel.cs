using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

// AccountModelResponse myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AccountModel
{
    public string? accountId { get; set; }
    public string? symbol { get; set; }
    public string? headquarters { get; set; }
    public int credits { get; set; }
    public string? startingFaction { get; set; }
}

public class AccountModelResponse
{
    [JsonPropertyName("Data")]
    public AccountModel? AccountModel { get; set; }
}
