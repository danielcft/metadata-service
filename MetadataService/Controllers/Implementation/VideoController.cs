using MetadataService.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using MetadataService.Services;

namespace MetadataService.Controllers.Implementation
{
  [Route("api/incoming/[controller]")]
  [ApiController]
  public class VideoController : ControllerBase, IVideoController
  {
    private readonly IVideoService _videoService;

    public VideoController(IVideoService videoService)
    {
      _videoService = videoService;
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]VideoInfo videoInfo)
    {
      _videoService.AddVideo( videoInfo);
    }
  }
}
