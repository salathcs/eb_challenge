using EB_Challenge.Web.Components.Pages.Videos;

namespace EB_Challenge.Web;

public class DomainApiClient(HttpClient httpClient)
{
    public async Task<IEnumerable<VideoData>> GetVideos()
    {
        var videoDatas = await httpClient.GetFromJsonAsync<VideoDatas>("/getVideos");

        return videoDatas!.VideoDataEnumerable;
    }

    public async Task AddVideo(IEnumerable<VideoData> videoDataEnumerable)
    {
        var response = await httpClient.PutAsJsonAsync("/addVideo", new VideoDatas(videoDataEnumerable));

        response.EnsureSuccessStatusCode();
    }

    public async Task ResetVideos()
    {
        await httpClient.DeleteAsync("/resetVideos");
    }
}

public record VideoDatas(IEnumerable<VideoData> VideoDataEnumerable);
