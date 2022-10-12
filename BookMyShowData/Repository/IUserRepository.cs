using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
        IEnumerable<User> GetUsers();
    }
}
