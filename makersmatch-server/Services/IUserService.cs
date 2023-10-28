namespace makersmatch_server.Services
{
    public interface IUserService
    {
        public Task<string> GetUserName(string UserId);
    }
}
