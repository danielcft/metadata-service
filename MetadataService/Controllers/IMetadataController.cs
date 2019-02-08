using System.Collections.Generic;
using MetadataService.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers
{
  interface IMetadataController
  {
    // GET api/Metadata/{id}
    [HttpGet("{id}")]
    ActionResult<CmsContent> Get(int id);

    // GET api/Metadata
    [HttpGet]
    ActionResult<List<int>> GetAll();
  }
}
