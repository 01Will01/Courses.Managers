
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Domain.Entities;

namespace Courses.Manager.Domain.Interfaces
{
    public interface IUserServices
    {
        User Login(UserDTO userDTO);
    }
}
