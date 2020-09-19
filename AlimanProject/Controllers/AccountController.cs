using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlimanProject.Models;

namespace AlimanProject.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("Chat");
        }

        // 
        public IActionResult Chat()
        {
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
