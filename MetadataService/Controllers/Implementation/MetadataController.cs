using System.Collections.Generic;
using MetadataService.Infrastructure.Entities;
using MetadataService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers.Implementation
{
  [Route("api/[controller]")]
  [ApiController]
  public class MetadataController : ControllerBase, IMetadataController
  {
    private readonly IMetadataService _metadataService;

    public MetadataController(IMetadataService metadataService)
    {
      _metadataService = metadataService;
    }

    // GET api/Metadata/{id}
    [HttpGet("{id}")]
    public ActionResult<CmsContent> Get(int id)
    {
      return _metadataService.Get(id);
    }

    // GET api/Metadata
    [HttpGet]
    public ActionResult<List<int>> GetAll()
    {
      return _metadataService.GetAll();
    }
  }
}
