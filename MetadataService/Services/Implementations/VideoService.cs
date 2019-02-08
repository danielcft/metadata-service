using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services.Implementations
{
  public class VideoService : IVideoService
  {
    private readonly IRepository<VideoInfo> _videoRepository;

    public VideoService(IRepository<VideoInfo> videoRepository)
    {
      _videoRepository = videoRepository;
    }

    public void AddVideo(VideoInfo videoInfo)
    {
        _videoRepository.Edit(videoInfo);
    }
  }
}