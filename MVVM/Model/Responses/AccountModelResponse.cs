using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

public class AccountModelResponse
{
    [JsonPropertyName("data")]
    public AccountModel? Data { get; set; }
}