using Microsoft.AspNetCore.Mvc;

namespace MetadataService.Controllers
{
  interface IAuthorizationController
  {
    // POST api/incoming/Authorization
    [HttpPost]
     void Post([FromBody] string samlResponse);
  }
}
