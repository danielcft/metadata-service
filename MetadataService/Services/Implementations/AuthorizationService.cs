using System;
using System.Linq;
using System.Security.Authentication;
using MetadataService.Infrastructure;
using MetadataService.Infrastructure.Entities;

namespace MetadataService.Services.Implementations
{
  public class AuthorizationService : IAuthorizationService
  {
    private readonly IRepository<AuthorizationCookie> _authorizationCookieRepository;

    public AuthorizationService(IRepository<AuthorizationCookie> authorizationCookieRepository)
    {
      _authorizationCookieRepository = authorizationCookieRepository;
    }

    public AuthorizationCookie AddAuthenticatedUser(string user, string role)
    {
      // check if user is already authenticated, if so, return the existing cookie
      var found = _authorizationCookieRepository.List().FirstOrDefault(p => p.User == user);
      if (found != null && found.ExpirationDate < DateTime.Now)
      {
        return found;
      }

      var auth = new AuthorizationCookie()
      {
        // TODO: this should be hashed with a salt to prevent cookie disclosure on eventual db leaks
        Cookie = Guid.NewGuid().ToString(),
        ExpirationDate = DateTime.Now.AddHours(1),
        Role = role,
        User = user
      };
      _authorizationCookieRepository.Add(auth);
      return auth;
    }
    /// <summary>
    /// Grant/Block access to a certain URI resource
    /// </summary>
    /// <param name="cookie"></param>
    /// <param name="uri"></param>
    public void Authorize(string cookie, string uri)
    {
      if (!string.IsNullOrEmpty(cookie))
      {
        AuthorizationCookie cookieFromDb = _authorizationCookieRepository.List().FirstOrDefault(p => p.Cookie == cookie);

        if (cookieFromDb != null && cookieFromDb.Role.Equals("developer_team_01"))
        {
          // 'developer_team_01' has access to all endpoints
          return;
        }
        if (cookieFromDb != null && cookieFromDb.Role.Equals("external_system_01"))
        {
          // "external_system_01' has access only to /incoming  
          if (uri.Contains("/incoming"))
          {
            return;
          }
        }
      }
      throw new AuthenticationException("Access to resource is not allowed.");
    }
  }
}
