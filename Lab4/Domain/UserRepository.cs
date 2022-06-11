using Lab4.Data;

namespace Lab4
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>() { new User("Admin","admin","Admin"),
        new User("User","user","User"),
        new User("User2","user2","User"),
        new User("User3","user3","User"),
        new User("User4","user4","User"),
        new User("User5","user5","User")
        };

        public async Task<User> GetAsync(string login)
         => await Task.FromResult(_users.SingleOrDefault(x => x.Login.ToLowerInvariant() == login.ToLowerInvariant()));


        public async Task<List<User>> GetAll()
        {
            return await Task.FromResult(_users);
        }
        public async Task AddAsync(User user)
        {
            var userExists = _users.SingleOrDefault(x => x.Login == user.Login);
            if(userExists != null)
            {
                throw new Exception("Login taken");
            }
            _users.Add(user);
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

    }
}
