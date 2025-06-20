using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class UserRepository : IUserRepository
    {
        MovieDbContext _movieDbContext;
        public UserRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public User Login(User user)
        {
            User userInfo = null;
            var result = _movieDbContext.users.Where(obj => obj.Email == user.Email && obj.Password == user.Password).ToList();
            if (result.Count > 0)
            {
                userInfo = result[0];
            }
            return userInfo;
        }

        public void Register(User userInfo)
        {
            _movieDbContext.users.Add(userInfo);
            _movieDbContext.SaveChanges();
        }
    }
}
