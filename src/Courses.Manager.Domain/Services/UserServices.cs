
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Domain.Entities;
using Courses.Manager.Domain.Interfaces;
using System;

namespace Courses.Manager.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(UserDTO userDTO)
        {
            _userRepository.Feeder();

            Guid? id = _userRepository.Exists(userDTO.UserName, userDTO.Password);

            if (id is null)
                throw new Exception("Usuário não localizado");

            User user = _userRepository.GetUser((Guid)id);

            return user;
        }
    }
}
