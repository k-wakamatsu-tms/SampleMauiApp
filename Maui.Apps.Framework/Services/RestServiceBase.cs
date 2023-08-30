using Maui.Apps.Framework.Exceptions;
using Maui.Apps.Framework.Extentions;
using System.Net.Http.Headers;
using System.Text.Json;

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

    protected void AddHttpHeader(string key, string value)
    {
        _httpClient.DefaultRequestHeaders.Add(key, value);
    }

    protected async Task<T> GetAsync<T>(string resource, int cacheDuration = 24)
    {
        //Get Json data
        var json = await GetJsonAsync(resource, cacheDuration);

        //return the result
        return JsonSerializer.Deserialize<T>(json);
    }

    private async Task<string> GetJsonAsync(string resource,int cacheDuration=24)
    {
        var cleanCacheKey = resource.CleanCacheKey();

        //check if cache barel is enable
        if (_cacheBarrel != null)
        {
            //check if data is in cache
            var cachedData =  _cacheBarrel.Get<string>(cleanCacheKey);

            if (cacheDuration > 0 && cachedData is not null && !_cacheBarrel.IsExpired(cleanCacheKey)) return cachedData;

            //check for internet conection and return cached data if possible
            if (_connectivity.NetworkAccess !=NetworkAccess.Internet)
            {
                return cachedData is not null ? cachedData:throw new InternetConnectionException();
            }
        }

        //no cache found or cached data was not required or internet connection is also available
        if(_connectivity.NetworkAccess !=NetworkAccess.Internet)
            throw new InternetConnectionException();

        //Extract response from URI
        var response=await _httpClient.GetAsync(new Uri(_httpClient.BaseAddress,resource));

        //check for valid response
        response.EnsureSuccessStatusCode();

        //read response
        string json=await response.Content.ReadAsStringAsync();

        //save to cache if required
        if(cacheDuration>0 && _cacheBarrel is not null)
        {
            try
            {
                _cacheBarrel.Add(cleanCacheKey, json, TimeSpan.FromHours(cacheDuration));
            }
            catch (Exception)
            {

                //throw;
            }

        }
    
        return json;

    }
}
