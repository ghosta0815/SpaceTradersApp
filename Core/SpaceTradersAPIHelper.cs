using SpaceTradersApp.MVVM.Model;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SpaceTradersApp.Core;

class SpaceTradersAPIHelper : ISpaceTradersAPIHelper
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SpaceTradersAPIHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public Task<AccountModel?> getAccountDataAsync()
    {
        throw new NotImplementedException();
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
