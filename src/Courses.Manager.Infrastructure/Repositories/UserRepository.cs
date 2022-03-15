
using Courses.Manager.Domain.Entities;
using Courses.Manager.Domain.Enums;
using Courses.Manager.Domain.Interfaces;
using Courses.Manager.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses.Manager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextCoursesManager _context;

        public UserRepository(DbContextCoursesManager dbContextCoursesManager)
        {
            _context = dbContextCoursesManager;
        }

        public Guid? Exists(string userName, string password)
        =>
        _context.Users
        .Where(data => data.UserName == userName && data.Password == password).FirstOrDefault()?.Id;

        public User GetUser(Guid id) => _context.Users.Where(data => data.Id == id).FirstOrDefault();

        /// <summary>
        /// Alimentador de usuários
        /// Create
        /// </summary>
        public void Feeder()
        {
            var user1 = new User()
            {
                UserName = "Roberta Guedes",
                Password = "123",
                Permissions = EPermissions.GeneralUser
            };

            var user2 = new User()
            {
                UserName = "Cleber Souza",
                Password = "123",
                Permissions = EPermissions.Manager
            };

            var user3 = new User()
            {
                UserName = "Willian Santos",
                Password = "123",
                Permissions = EPermissions.Secretary
            };

            new List<User>() { user1, user2, user3 }
            .ForEach(user =>
            {
                if (!_context.Users.Any(data => data.UserName == user.UserName))
                    _context.Users.Add(user);
            });

            _context.SaveChangesAsync().Wait();
        }
    }
}
