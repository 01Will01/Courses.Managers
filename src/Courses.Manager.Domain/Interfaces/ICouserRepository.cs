
using Courses.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Courses.Manager.Domain.Interfaces
{
    public interface ICouserRepository
    {
        Task<List<Course>> Get();

        Task<Course> Details(Guid id);

        void Remove(Guid id);

        void Update(Course course);

        void Create(Course course);
    }
}
