
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Domain.Entities;
using Courses.Manager.Domain.Enums;
using Courses.Manager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Courses.Manager.Domain.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICouserRepository _couserRepository;

        public CourseServices(ICouserRepository couserRepository)
        {
            _couserRepository = couserRepository;
        }

        public async Task<IEnumerable<CoursesDTO>> Get()
        {
            List<Course> cousers = await _couserRepository.Get();

            List<CoursesDTO> coursesDTOs = new List<CoursesDTO>();

            cousers.ForEach(course =>
            {
                CoursesDTO coursesDTO = new CoursesDTO()
                {
                    Id = course.Id,
                    Duration = course.Duration,
                    Status = course.Status,
                    Title = course.Title
                };

                coursesDTOs.Add(coursesDTO);
            });

            return coursesDTOs;
        }

        public async Task<CoursesDTO> Details(Guid id)
        {
            var course = await _couserRepository.Details(id);

            if (course is null)
                return null;

            CoursesDTO coursesDTO = new CoursesDTO()
            {
                Id = course.Id,
                Duration = course.Duration,
                Status = course.Status,
                Title = course.Title
            };

            return coursesDTO;
        }

        public void Create(User user, CoursesDTO coursesDTO)
        {
            if (user.Permissions == EPermissions.Manager || user.Permissions == EPermissions.Secretary)
            {
                Course course = new Course()
                {
                    Id = coursesDTO.Id,
                    Duration = coursesDTO.Duration,
                    Status = coursesDTO.Status,
                    Title = coursesDTO.Title
                };

                _couserRepository.Create(course);
            }
        }
        public void Update(User user, CoursesDTO coursesDTO)
        {
            if (user.Permissions == EPermissions.Manager || user.Permissions == EPermissions.Secretary)
            {
                Course course = new Course()
                {
                    Id = coursesDTO.Id,
                    Duration = coursesDTO.Duration,
                    Status = coursesDTO.Status,
                    Title = coursesDTO.Title
                };

                _couserRepository.Update(course);
            }
        }
        public void Remove(User user, Guid id)
        {
            if (user.Permissions == EPermissions.Manager || user.Permissions == EPermissions.Secretary)
            {
                _couserRepository.Remove(id);
            }
        }
    }
}
