using MetadataService.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers
{
  interface IVideoController
  {
    [HttpPut("{id}")]
    void Put(int id, [FromBody] VideoInfo videoInfo);
  }
}
