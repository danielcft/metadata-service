using System.Collections.Generic;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services
{
  public interface IMetadataService
  {
    CmsContent Get(int id);
    List<int> GetAll();
  }
}
