using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using AutoMapper;

using HR.LeaveManagement.Mvc.Contracts;
using HR.LeaveManagement.Mvc.Models;
using HR.LeaveManagement.Mvc.Services.Base;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

using IAuthenticationService = HR.LeaveManagement.Mvc.Contracts.IAuthenticationService;

namespace HR.LeaveManagement.Mvc.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthenticationService(
            ILocalStorageService localStorage,
            IClient client,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(localStorage, client)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var authRequest = new AuthRequest { Email = email, Password = password };
                var authResponse = await _client.LoginAsync(authRequest);

                if (string.IsNullOrEmpty(authResponse.Token))
                {
                    return false;
                }

                // Get Claims from token and Build auth user object
                var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                var claims = ParseClaims(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                if (_httpContextAccessor.HttpContext == null)
                {
                    return false;
                }

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorage.SetStorageValue("token", authResponse.Token);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(RegisterVM register)
        {
            var registrationRequest = _mapper.Map<RegistrationRequest>(register);

            var response = await _client.RegisterAsync(registrationRequest);

            if (string.IsNullOrEmpty(response.UserId))
            {
                return false;
            }

            await Authenticate(register.Email, register.Password);
            return true;
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });

            if (_httpContextAccessor.HttpContext != null)
            {
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }

        private static IEnumerable<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
