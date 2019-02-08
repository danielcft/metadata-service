using Microsoft.AspNetCore.Mvc;
using MetadataService.Infrastructure.Entities;
using MetadataService.Services;

namespace MetadataService.Controllers.Implementation
{
  [Route("api/incoming/[controller]")]
  [ApiController]
  public class ThemeController : ControllerBase, IThemeController
  {
    private readonly IThemeService _themeService;

    public ThemeController(IThemeService themeService)
    {
      _themeService = themeService;
    }

    // POST api/Theme
    [HttpPost]
    public void Post([FromBody] Theme theme)
    {
      _themeService.Create(theme);
    }

    // PUT api/Theme
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]  Theme theme)
    {
      _themeService.Update(theme);
    }

    // DELETE api/Theme/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _themeService.Delete(id);
    }
  }
}
