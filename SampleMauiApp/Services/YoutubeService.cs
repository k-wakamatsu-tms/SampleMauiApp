
using System.Net;

namespace SampleMauiApp.Services;

public class YoutubeService : RestServiceBase, IApiService
{
    protected YoutubeService(IBarrel cacheBarrel, IConnectivity connectivity) : base(cacheBarrel, connectivity)
    {
        SetBaseURL(Constants.ApiServiceURL);
    }

    public Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "")
    {
        var resourceUri = $"search?part=snippet&maxResults=10&type=video&key=[API_KEY]&q={WebUtility.UrlEncode(searchQuery)}"
            +
            (!string.IsNullOrEmpty(nextPageToken) ? $"&pageToken={nextPageToken}" : "");

        var result = GetAsync<VideoSearchResult>(resourceUri, 4);

        return result;
    }
}
