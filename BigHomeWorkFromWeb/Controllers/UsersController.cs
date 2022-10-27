using BigHomeWorkFromWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BigHomeWorkFromWeb.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var users = await UserHelper.GetUsers();
 
            return View(users);
        }
        public async Task<IActionResult> FullInfoForUsers()
        {
            var users = await UserHelper.GetUsers();

            return View(users);
        }
        [HttpGet]
        public IActionResult AddUsers()
        {      
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUsers(UserModel userModel)
        {
            await UserHelper.AddUser(userModel);

            return RedirectToAction("Index", "Home"); ;
        }

        [HttpGet]
        public IActionResult Remove()
        {
            UserModel user = new UserModel();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(UserModel userModel)
        {
            await UserHelper.Remove(userModel);

            return RedirectToAction("Index", "Home"); ;
        }
    }
}
