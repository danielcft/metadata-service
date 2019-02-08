using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services
{
  public interface IAuthorizationService
  {
    AuthorizationCookie AddAuthenticatedUser(string user, string role);
    void Authorize(string cookie, string uri);
  }
}
