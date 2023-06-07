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
    private string _Token = "";

    public string Token
    {
        get { return _Token; }
        set { _Token = value; }
    }


    private readonly IHttpClientFactory _httpClientFactory;

    public SpaceTradersAPIHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<AccountModelResponse?> getAccountDataAsync()
    {
        var httpClient = _httpClientFactory.CreateClient("SpaceTradersAPI");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var stringResponse = await httpClient.GetStringAsync("my/agent");
        var response = await httpClient.GetFromJsonAsync<AccountModelResponse>("my/agent");

        return response;
    }

    //   public async Task<AccountModel?> getAccountDataAsync()
    //   {
    //       var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spacetraders.io/v2/my/agent");
    //       var client = _httpClientFactory.CreateClient("SpaceTradersIOClient");
    //
    //       HttpResponseMessage response = await client.SendAsync(request);
    //
    //       throw NotImplementedException();
    //
    //   }
}
