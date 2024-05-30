namespace EB_Challenge.DomainService;

public record SyncVideo
{
    public int Id { get; set; }

    public required VideoDatas VideoDatas { get; set; }
}

public record VideoDatas
{
    public required IEnumerable<VideoData> VideoDataEnumerable { get; set; }
}

public record VideoData
{
    public required int Width { get; set; }

    public required int Height { get; set; }

    public required string Video { get; set; }
}
