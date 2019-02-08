using MetadataService.Authorization;
using MetadataService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens.Saml2;

namespace MetadataService.Controllers.Implementation
{
  [Route("api/incoming/[controller]")]
  public class AuthorizationController : ControllerBase, IAuthorizationController
  {
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationController(IAuthorizationService authorizationService)
    {
      _authorizationService = authorizationService;
    }

    // POST api/incoming/Authorization
    [HttpPost]
    public void Post([FromBody] string samlResponse)
    {
      ISamlResponseToken token = new SamlResponseToken(samlResponse);

      if (token.IsValid() == false)
      {
        throw new Saml2SecurityTokenException("SAML Token is not valid.");
      }

      var cookie = _authorizationService.AddAuthenticatedUser(token.GetUser(), token.GetRole());
      Response.Cookies.Append("session-id", cookie.Cookie);
    }
  }
}