using MetadataService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Authentication;
using MetadataService.Controllers.Implementation;

namespace MetadataService.Authorization
{
  /// <summary>
  /// Inspect all requests and grant/block access to controllers 
  /// </summary>
  public class AuthorizationFilter : IActionFilter
  {
    private IAuthorizationService _authorizationService;

    public AuthorizationFilter(IAuthorizationService authorizationService)
    {
      _authorizationService = authorizationService;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
      // OnActionExecuted is called before the action executes

      if (context.Controller.GetType() == typeof(AuthorizationController))
      {
        // bypass cookie verification => it is not needed for this controller
        return;
      }

      var cookie = context.HttpContext.Request?.Cookies["session-id"];
      var uri = context.HttpContext?.Request?.Path;
      try
      {
        _authorizationService.Authorize(cookie, uri);
      }
      catch (AuthenticationException)
      {
        context.Result = new UnauthorizedResult();
      }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      // OnActionExecuting is called after the action executes
    }
  }
}