using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services
{
  public interface IVideoService
  {
    void AddVideo(VideoInfo videoInfo);
  }
}
