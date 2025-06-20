using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface IUserRepository
    {
        void Register(User userInfo);
        User Login(User user);
    }
}
