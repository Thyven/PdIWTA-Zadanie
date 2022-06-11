using Lab4.Data;

namespace Lab4
{
    public interface IUserService
    {
        public Task RegisterAsync(string Login, string Paswword,string role);
        public Task<Token> LoginAsync(string Login, string password);
        public Task<List<User>> GetAllUser();
    }
}
