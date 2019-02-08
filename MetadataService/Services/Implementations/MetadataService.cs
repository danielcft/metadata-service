using System.Collections.Generic;
using System.Linq;
using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services.Implementations
{
    public class MetadataService : IMetadataService
    {
        private readonly IRepository<CmsContent> _cmsContentRepository;

        public MetadataService(IRepository<CmsContent> cmsContentRepository)
        {
            _cmsContentRepository = cmsContentRepository;
        }

        public CmsContent Get(int id)
        {
            return _cmsContentRepository.List(p => p.Id == id,
                p => p.VideoInfo).FirstOrDefault();
        }

        public List<int> GetAll()
        {
            var result =  _cmsContentRepository
              .List(c=> c.VideoInfo!=null && c.VideoInfo.State== VideoInfo.VideoState.Available, c=> c.VideoInfo)
              .ToList();
            return result.Select(cmsContent => cmsContent.Id).ToList();
        }
    }
}
