using Microsoft.EntityFrameworkCore;

namespace EB_Challenge.DomainService;

public class VideosDbContext : DbContext
{
    public VideosDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<SyncVideo> SyncVideos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SyncVideo>().OwnsOne(
            sync => sync.VideoDatas, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsMany(contactDetails => contactDetails.VideoDataEnumerable);
            });
    }
}
