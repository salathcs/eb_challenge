using Microsoft.AspNetCore.SignalR;

namespace EB_Challenge.SignalRService;

public class VideosHub : Hub
{
    public async Task AddVideo(int width, int height, string video)
    {
        await Clients.All.SendAsync("SyncAddVideo", width, height, video);
    }

    public async Task ResetVideos()
    {
        await Clients.All.SendAsync("SyncResetVideos");
    }
}
