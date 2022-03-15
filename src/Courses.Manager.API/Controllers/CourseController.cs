using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Courses.Manager.Domain.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Courses.Manager.Shared;
using Courses.Manager.Domain.Entities;
using Courses.Manager.Domain.Interfaces;

namespace Courses.Manager.API.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseServices _courseServices;
        private readonly IMemoryCache _memoryCache;

        public CourseController(IMemoryCache memoryCache, ICourseServices courseServices)
        {
            _memoryCache = memoryCache;
            _courseServices = courseServices;
        }

        public async Task<IActionResult> Index()
        {
            CheckLogin("");
            return View(await _courseServices.Get()); ;
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoursesDTO course = await _courseServices.Details((Guid)id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoursesDTO coursesDTO)
        {
            _memoryCache.TryGetValue(Settings.KEYUSERCURRENT, out User user);
            if (ModelState.IsValid)
            {

                _courseServices.Create(user, coursesDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(coursesDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesDTO = await _courseServices.Details((Guid)id);
            if (coursesDTO == null)
            {
                return NotFound();
            }
            return View(coursesDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, CoursesDTO coursesDTO)
        {
            _memoryCache.TryGetValue(Settings.KEYUSERCURRENT, out User user);

            if (id != coursesDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseServices.Update(user, coursesDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesDTOExists(coursesDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coursesDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesDTO = await _courseServices.Details((Guid)id);
            if (coursesDTO == null)
            {
                return NotFound();
            }

            return View(coursesDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _memoryCache.TryGetValue(Settings.KEYUSERCURRENT, out User user);

            _courseServices.Remove(user, id);

            return RedirectToAction(nameof(Index));
        }

        private bool CoursesDTOExists(Guid id)
        {
            return !(_courseServices.Details((Guid)id) is null);
        }

        private IActionResult CheckLogin(string redicrect)
        {
            if (!_memoryCache.TryGetValue(Settings.KEYUSERACESS, out User user))
            {
                return RedirectToAction("Login", "User", new { area = "" });
            }
            else
                _memoryCache.Remove(Settings.KEYUSERACESS);

            _memoryCache.Set(
            Settings.KEYUSERCURRENT,
            user,
            new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1800),
                SlidingExpiration = TimeSpan.FromSeconds(150)
            });

            return RedirectToAction(redicrect);
        }
    }
}
