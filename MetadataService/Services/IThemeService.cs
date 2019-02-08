using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services
{
  public interface IThemeService
  {
    void Create(Theme theme);
    void Update(Theme theme);
    void Delete(int id);
  }
}
