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
    public Data? Data { get; set; }
}


public class DataModel
{
    public Data? Data { get; set; }
}

public class Data
{
    public string? accountId { get; set; }
    public string? symbol { get; set; }
    public string? headquarters { get; set; }
    public int credits { get; set; }
    public string? startingFaction { get; set; }
}
