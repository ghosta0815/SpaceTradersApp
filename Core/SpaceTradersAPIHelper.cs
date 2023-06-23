using SpaceTradersApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
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

    /// <summary>
    /// Serialization options for serializing HTTP Requests
    /// </summary>
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
    public async Task<AgentModel?> getMyAgentAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("SpaceTradersAPI");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var responseMessage = await httpClient.GetAsync("my/agent");
        AgentModel? accountModel = null;
        if(responseMessage.IsSuccessStatusCode)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            accountModel = JsonSerializer.Deserialize<AgentModelResponse?>(responseString, _jsonSerializerOptions)?.Data;
        }
        
        return accountModel;
    }

    /// <summary>
    /// Method to get a paginated List of available Ships
    /// </summary>
    /// <returns>The List of Ships including the pagination info</returns>
    public async Task<FleetModelResponse?> getShipsDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("SpaceTradersAPI");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var responseMessage = await httpClient.GetAsync("my/ships");
        FleetModelResponse? shipModelResponse = null;
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            shipModelResponse = JsonSerializer.Deserialize<FleetModelResponse?>(responseString, _jsonSerializerOptions);
        }

        return shipModelResponse;
    }

    /// <summary>
    /// Creates a new user agent
    /// </summary>
    /// <param name="agentName">The name of the new agent</param>
    /// <param name="selectedFaction">The faction, the account is created in</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<AccountModel?> RegisterNewAccountAsync(string agentName, string? selectedFaction)
    {
        var httpClient = _httpClientFactory.CreateClient("SpaceTradersAPI");
        var registerAgentRequest = new RegisterAgentRequest()
        {
            Symbol = agentName,
            Faction = selectedFaction
        };

        var requestMessage = new StringContent(JsonSerializer.Serialize(registerAgentRequest), 
            Encoding.UTF8, "application/json");

        var responseMessage = await httpClient.PostAsync("register", requestMessage);

        AccountModelResponse? accountModelResponse = null;
        if (responseMessage.IsSuccessStatusCode)
        {
            var responseString = await responseMessage.Content.ReadAsStringAsync();

            accountModelResponse = JsonSerializer.Deserialize<AccountModelResponse?>(responseString, _jsonSerializerOptions);
        }
        else return null;

        return accountModelResponse!.Data;

    }
    #endregion
}
