/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Andromede.Authentication
{
    public class AndromedeAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorageService;

        public AndromedeAuthenticationStateProvider(ILocalStorageService iLocalStorageService)
        {
            _localStorageService = iLocalStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            int? anId              = await _localStorageService.GetItemAsync<int>("sId");
            string anEmailAdress   = await _localStorageService.GetItemAsync<string>("sEmailAddress");
            ClaimsIdentity anIdentity;

            if (anId != null && anEmailAdress != null)
            {
                anIdentity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, anId.ToString()),
                    new Claim(ClaimTypes.Email, anEmailAdress),
                }, "apiauth_type") ;
            }
            else
            {
                anIdentity = new ClaimsIdentity();
            }

            ClaimsPrincipal anUser = new ClaimsPrincipal(anIdentity);

            return await Task.FromResult(new AuthenticationState(anUser));
        }

        public void RestorerIsAuthenticated(int iId)
        {
            ClaimsIdentity anIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, iId.ToString())
            }, "apiauth_type");

            ClaimsPrincipal aRestorer = new ClaimsPrincipal(anIdentity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(aRestorer)));
        }

        public void RestorerIsLoggedOut()
        {
            _localStorageService.RemoveItemAsync("sId");
            _localStorageService.RemoveItemAsync("sEmailAddress");

            ClaimsIdentity anIdentity = new ClaimsIdentity();

            ClaimsPrincipal aRestorer = new ClaimsPrincipal(anIdentity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(aRestorer)));
        }

    }
}
