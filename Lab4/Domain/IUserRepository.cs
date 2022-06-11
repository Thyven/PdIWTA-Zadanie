﻿using Lab4.Data;

namespace Lab4
{
    public interface IUserRepository
    { 
        
        public  Task<User> GetAsync(string email);
        public  Task<List<User>> GetAll();
        public  Task AddAsync(User user);
        public  Task DeleteAsync(User user);
        public  Task UpdateAsync(User user);
    
    }
}
