using System;

namespace Lab4
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Save(User user);
    }
}
