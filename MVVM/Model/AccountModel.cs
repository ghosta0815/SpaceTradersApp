using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

// AccountModelResponse myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class AccountModel
{
    public string? AccountId { get; set; }
    public string? Symbol { get; set; }
    public string? Headquarters { get; set; }
    public int Credits { get; set; }
    public string? StartingFaction { get; set; }
}

public class AccountModelResponse
{
    public AccountModel? Data { get; set; }
}

