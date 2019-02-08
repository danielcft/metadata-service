using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services.Implementations
{
  public class ThemeService : IThemeService
  {
    private readonly IRepository<Theme> _themeRepository;

    public ThemeService(IRepository<Theme> themeRepository)
    {
      _themeRepository = themeRepository;
    }

    public void Create(Theme theme)
    {
      _themeRepository.Add(theme);
    }

    public void Update(Theme theme)
    {
      _themeRepository.Edit(theme);
    }

    public void Delete(int id)
    {
      var toDelete = _themeRepository.GetById(id);
      _themeRepository.Delete(toDelete);
    }
  }
}
