using Microsoft.AspNetCore.Mvc.Filters;
using System;
using MetadataService.Services;
using MetadataService.Services.Implementations;

namespace MetadataService.Authorization
{
  public class AuthorizationFilterFactory : IFilterFactory
  {
    public bool IsReusable => false;

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
      var authService = (AuthorizationService)serviceProvider.GetService(typeof(IAuthorizationService));
      return new AuthorizationFilter(authService);
    }
  }
}
