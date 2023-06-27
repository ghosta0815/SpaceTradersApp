using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SpaceTradersApp.MVVM.Model;

/// <summary>
/// POST https://api.spacetraders.io/v2/register
/// </summary>
public class RegisterModelResponse
{
    /// <summary>
    /// The response for registering a new account
    /// </summary>
    [JsonPropertyName("data")]
    public AccountModel? Data { get; set; }
}