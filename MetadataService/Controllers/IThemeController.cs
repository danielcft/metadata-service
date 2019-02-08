using MetadataService.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers
{
  interface IThemeController
  {
    // POST api/Theme
    [HttpPost]
    void Post([FromBody] Theme theme);

    // PUT api/Theme
    [HttpPut("{id}")]
    void Put(int id, [FromBody] Theme theme);

    // DELETE api/Theme/{id}
    [HttpDelete("{id}")]
    void Delete(int id);
  }
}
