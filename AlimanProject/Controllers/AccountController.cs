using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlimanProject.Models;
using Microsoft.AspNetCore.Identity;

namespace AlimanProject.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<ApplicationUser> SignInManager;
        UserManager<ApplicationUser> UserManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            
            if (SignInManager.IsSignedIn(User))
            {
                return RedirectToAction("Chat");
            }

            return RedirectToAction("Signin", "Account", new { area = "Identity" });
        }

        // 
        public IActionResult Chat()
        {
            ViewBag.PhoneNumber = UserManager.GetUserName(User);

            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Calls()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Photos()
        {
            return View();
        }

        public IActionResult Guest()
        {
            return View();
        }
    }
}
