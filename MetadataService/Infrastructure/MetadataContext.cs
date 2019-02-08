using MetadataService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MetadataService.Infrastructure
{
  public class MetadataContext: DbContext
  {
      public MetadataContext(DbContextOptions<MetadataContext> options) : base(options)
      {
      }
      public DbSet<Theme> Themes { get; set; }
      public DbSet<CmsContent> CmsContents { get; set; }
      public DbSet<VideoInfo> VideoInfos { get; set; }
      public DbSet<AuthorizationCookie> AuthorizationCookies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
      {

      }
    }
}
