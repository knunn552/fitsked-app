namespace FitskedApp.Data.Repository
{
    public interface IUserRepository
    {
        public Task<string> GetCurrentUserUserId();
    }
}
