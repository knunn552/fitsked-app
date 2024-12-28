
using FitskedApp.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace FitskedApp.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationStateProvider _state;

        public UserRepository(AuthenticationStateProvider state)
        {
            this._state = state;
        }
        public async Task<string> GetCurrentUserUserId()
        {
            var authState = await _state.GetAuthenticationStateAsync();
            var user = authState.User;


            if (user.Identity?.IsAuthenticated == true)
            {
                var userId = user.FindFirst(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    return userId;
                }

            }
            return null;
        }
    }
}
