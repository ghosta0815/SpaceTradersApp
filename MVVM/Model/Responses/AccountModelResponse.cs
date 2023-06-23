using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// A class representing the response after registering a new agent
/// </summary>
public class AccountModelResponse
{
    /// <summary>
    /// The response for registering a new account
    /// </summary>
    [JsonPropertyName("data")]
    public AccountModel? Data { get; set; }
}