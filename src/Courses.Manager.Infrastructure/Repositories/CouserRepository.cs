using Courses.Manager.Domain.Entities;
using Courses.Manager.Domain.Interfaces;
using Courses.Manager.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Manager.Infrastructure.Repositories
{
    public class CouserRepository : ICouserRepository
    {
        private readonly DbContextCoursesManager _context;

        public CouserRepository(DbContextCoursesManager dbContextCoursesManager)
        {
            _context = dbContextCoursesManager;
        }

        public async Task<List<Course>> Get() => await _context.Courses.ToListAsync();
        public async Task<Course> Details(Guid id) => await _context.Courses.FirstOrDefaultAsync(m => m.Id == id);


        public void Create(Course course)
        {
            course.Id = Guid.NewGuid();
            _context.Add(course);
            _context.SaveChanges();
        }
        public void Update(Course course)
        {
            _context.Update(course);
            _context.SaveChanges();
        }
        public void Remove(Guid id)
        {
            var coursesDTO = _context.Courses.Find(id);
            _context.Courses.Remove(coursesDTO);
            _context.SaveChanges();
        }


    }
}
