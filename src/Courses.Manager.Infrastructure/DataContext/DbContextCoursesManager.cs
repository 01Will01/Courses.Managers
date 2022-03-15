
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Courses.Manager.Infrastructure.DataContext
{
    public class DbContextCoursesManager : DbContext
    {
        public DbContextCoursesManager(DbContextOptions<DbContextCoursesManager> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
