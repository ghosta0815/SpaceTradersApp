using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core;

class SpaceTradersAPIHelper : ISpaceTradersAPIHelper
{
    #region private Members
    /// <summary>
    /// The Bearer token to access the user
    /// </summary>
    private string _Token = "";

    /// <summary>
    /// The Client Factory to get the Http Client for making the Calls
    /// SpaceTraders API: SpaceTradersAPI
    /// </summary>
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    #endregion

    #region public Members
    /// <summary>
    /// The Bearer Token to access the User Agent
    /// </summary>
    public string Token
    {
        get { return _Token; }
        set { _Token = value; }
    }
    #endregion


    #region Constructors
    /// <summary>
    /// The Default Constructor
    /// </summary>
    /// <param name="httpClientFactory">The Client Factory for the Space Traders API</param>
    public SpaceTradersAPIHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    #endregion

    #region Async Methods
    /// <summary>
    /// Method to get the Account Data
    /// </summary>
    /// <returns>The Account Model for this Account if the call was successful</returns>
    public async Task<AccountModel?> getAccountDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("SpaceTradersAPI");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var responseMessage = await httpClient.GetAsync("my/agent");
        AccountModel? accountModel = null;
        if(responseMessage.IsSuccessStatusCode)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            accountModel = JsonSerializer.Deserialize<AccountModelResponse?>(responseString, _jsonSerializerOptions)?.Data;
        }
        
        return accountModel;
    }
    #endregion
}
