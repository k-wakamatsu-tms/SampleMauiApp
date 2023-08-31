
namespace SampleMauiApp.Services;

public class YoutubeService : RestServiceBase, IApiService
{
    protected YoutubeService(IBarrel cacheBarrel, IConnectivity connectivity) : base(cacheBarrel, connectivity)
    {
        SetBaseURL(Constants.ApiServiceURL);
    }

    public Task<VideoSearchResult> SearchVideos(string searchQuery, string nextPageToken = "")
    {
        var resourceUri = "";
    }
}
