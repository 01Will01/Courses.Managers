using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Courses.Manager.Domain.DTOs;
using Courses.Manager.Infrastructure.DataContext;
using Courses.Manager.Domain.Interfaces;
using Courses.Manager.Domain.Entities;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Courses.Manager.Shared;

namespace Courses.Manager.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IMemoryCache _memoryCache;

        public UserController(IMemoryCache memoryCache, IUserServices userServices)
        {
            _memoryCache = memoryCache;
            _userServices = userServices;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserDTO userDTO)
        {

            _memoryCache.Remove(Settings.KEYUSERCURRENT);

            if (ModelState.IsValid)
            {
                User user = _userServices.Login(userDTO);

                _memoryCache.Set(
                    Settings.KEYUSERACESS,
                    user,
                    new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1800),
                        SlidingExpiration = TimeSpan.FromSeconds(150)
                    });

                return RedirectToAction("Index", "Course", new { area = "" });
            }
            return View(userDTO);
        }
    }
}
