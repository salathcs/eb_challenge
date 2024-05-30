using Microsoft.EntityFrameworkCore;

namespace EB_Challenge.DomainService;

public class VideosService(VideosDbContext _context)
{
    public async Task<SyncVideo> GetSyncVideo()
    {
        var syncVideo = await _context.SyncVideos.FirstOrDefaultAsync();
        if (syncVideo is null)
        {
            syncVideo = new SyncVideo { VideoDatas = new VideoDatas { VideoDataEnumerable = [] } };
            _context.SyncVideos.Add(syncVideo);
            await _context.SaveChangesAsync();
        }

        return syncVideo;
    }

    public async Task AddVideo(VideoDatas videoDatas)
    {
        var syncVideo = await _context.SyncVideos.FirstOrDefaultAsync();

        if (syncVideo is null)
        {
            syncVideo = new SyncVideo { VideoDatas = videoDatas };
            _context.SyncVideos.Add(syncVideo);
        }
        else
        {
            syncVideo.VideoDatas = videoDatas;
        }

        await _context.SaveChangesAsync();
    }

    public async Task ClearVideos()
    {
        var syncVideo = await _context.SyncVideos.FirstOrDefaultAsync();

        if (syncVideo is null)
        {
            syncVideo = new SyncVideo { VideoDatas = new VideoDatas { VideoDataEnumerable = [] } };
            _context.SyncVideos.Add(syncVideo);
        }
        else
        {
            syncVideo.VideoDatas = new VideoDatas { VideoDataEnumerable = [] };
        }

        await _context.SaveChangesAsync();
    }
}
