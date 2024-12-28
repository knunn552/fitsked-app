namespace FitskedApp.Utilities
{
    public interface IUserService
    {
        public Task<bool> IsUserAuthenticatedAsync(); // Might need to use multiple implementation of this method as we'll most likely be integrating with Microsoft Entra Id in the future.
    }
}
