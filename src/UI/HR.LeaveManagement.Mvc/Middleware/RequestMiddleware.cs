using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Services.Base;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace HR.LeaveManagement.Mvc.Middleware
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILocalStorageService _localStorageService;

        public RequestMiddleware(RequestDelegate next, ILocalStorageService localStorageService)
        {
            _next = next;
            _localStorageService = localStorageService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
                var authAttribute = endpoint?.Metadata?.GetMetadata<AuthorizeAttribute>();
                if (authAttribute != null)
                {
                    var tokenExists = _localStorageService.Exists("token");
                    var tokenIsValid = true;

                    if (tokenExists)
                    {
                        var token = _localStorageService.GetStorageValue<string>("token");
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenContent = tokenHandler.ReadJwtToken(token);
                        var expiry = tokenContent.ValidTo;

                        if (expiry < DateTime.UtcNow)
                        {
                            tokenIsValid = false;
                        }
                    }

                    if (tokenIsValid == false || tokenExists == false)
                    {
                        await SignOutAndRedirect(httpContext);
                        return;
                    }

                    if (authAttribute.Roles is not null)
                    {
                        var userRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;

                        if (userRole is not null)
                        {
                            if (authAttribute.Roles.Contains(userRole) == false)
                            {
                                httpContext.Response.Redirect("/home/notauthorized");
                                return;
                            }
                        }
                    }
                }

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task SignOutAndRedirect(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var path = "/user/login";
            httpContext.Response.Redirect(path);
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            switch (exception)
            {
                case ApiException:
                    await SignOutAndRedirect(httpContext);
                    break;
                default:
                    var path = "/Home/Error";
                    httpContext.Response.Redirect(path);
                    break;
            }
        }
    }
}
