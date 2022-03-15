
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Courses.Manager.Domain.Interfaces
{
    public interface ICourseServices
    {
        Task<IEnumerable<CoursesDTO>> Get();
        Task<CoursesDTO> Details(Guid id);
        void Update(User user, CoursesDTO coursesDTO);

        void Create(User user, CoursesDTO coursesDTO);
        void Remove(User user, Guid id);
    }
}
