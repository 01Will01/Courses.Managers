
using Courses.Manager.Domain.Entities;
using System;

namespace Courses.Manager.Domain.Interfaces
{
    public interface IUserRepository
    {
        Guid? Exists(string userName, string password);
        User GetUser(Guid id);

        void Feeder();
    }
}
