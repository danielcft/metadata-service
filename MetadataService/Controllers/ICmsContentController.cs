using MetadataService.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers
{
  interface ICmsContentController
  {
    // POST api/incoming/CmsContent
    [HttpPost]
    void Post([FromBody] CmsContent cmsContent);

    // PUT api/incoming/CmsContent/{id}
    [HttpPut("{id}")]
    void Put(int id, [FromBody]  CmsContent cmsContent);

    // DELETE api/incoming/CmsContent/{id}
    [HttpDelete("{id}")]
    void Delete(int id);
  }
}
