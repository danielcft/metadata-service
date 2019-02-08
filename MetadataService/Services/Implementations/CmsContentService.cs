using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services.Implementations
{
  public class CmsContentService : ICmsContentService 
  {
    private readonly IRepository<CmsContent> _cmsContentRepository;

    public CmsContentService(IRepository<CmsContent> cmsContentRepository)
    {
      _cmsContentRepository = cmsContentRepository;
    }

    public void Create(CmsContent cmsContent)
    {
      _cmsContentRepository.Add(cmsContent);
    }

    public void Update(CmsContent cmsContent)
    {
      _cmsContentRepository.Edit(cmsContent);
    }

    public void Delete(int id)
    {
      var toDelete = _cmsContentRepository.GetById(id);
      _cmsContentRepository.Delete(toDelete);
    }
  }
}
