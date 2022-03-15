
using Courses.Manager.Domain.Interfaces;
using Courses.Manager.Domain.Services;
using Courses.Manager.Infrastructure.DataContext;
using Courses.Manager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Courses.Manager.Infrastructure.IoC
{
    public class InjectionOfContainer
    {
        public static void ConfigureInjection(IServiceCollection services)
        {
            services.AddScoped<DbContextCoursesManager>();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICourseServices, CourseServices>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICouserRepository, CouserRepository>();
        }
    }
}
