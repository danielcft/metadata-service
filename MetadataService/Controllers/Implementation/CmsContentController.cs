using MetadataService.Infrastructure.Entities;
using MetadataService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers.Implementation
{
  [Route("api/incoming/[controller]")]
  [ApiController]
  public class CmsContentController : ControllerBase, ICmsContentController
  {
    private readonly ICmsContentService _cmsContentService;

    public CmsContentController(ICmsContentService cmsContentService)
    {
      _cmsContentService = cmsContentService;
    }

    // POST api/incoming/CmsContent
    [HttpPost]
    public void Post([FromBody] CmsContent cmsContent)
    {
      _cmsContentService.Create(cmsContent);
    }

    // PUT api/incoming/CmsContent/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]  CmsContent cmsContent)
    {
      _cmsContentService.Update(cmsContent);
    }

    // DELETE api/incoming/CmsContent/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _cmsContentService.Delete(id);
    }
  }
}
