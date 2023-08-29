using System.Net.Http.Headers;

namespace Maui.Apps.Framework.Services;

public class RestServiceBase
{
    private HttpClient _httpClient;
    private IBarrel _cacheBarrel;
    private IConnectivity _connectivity;

    protected RestServiceBase(IBarrel cacheBarrel, IConnectivity connectivity)
    {
        _cacheBarrel = cacheBarrel;
        _connectivity = connectivity;
    }

    protected void SetBaseURL(string baseURL)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseURL)
        };

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
