using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FitskedApp.Utilities
{
    public class IdentityUserService : IUserService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public IdentityUserService(AuthenticationStateProvider authenticationStateProvider)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            return authState.User.Identity?.IsAuthenticated == true;
        }

        public async Task<string> GetAuthenticatedUserIdAsync()
        {
            if (await IsUserAuthenticatedAsync())
            {
                var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;
                return user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
        }

    }
}
