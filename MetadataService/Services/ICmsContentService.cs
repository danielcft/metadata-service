using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services
{
  public interface ICmsContentService
  {
    void Create(CmsContent cmsContent);
    void Update(CmsContent cmsContent);
    void Delete(int id);
  }
}
