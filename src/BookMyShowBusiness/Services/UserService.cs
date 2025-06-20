using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(User userInfo)
        {
            _userRepository.Register(userInfo);
        }
        public User Login(User user)
        {
            return _userRepository.Login(user);
        }
    }
}
