using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlimanProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccountChats()
        {
            return View();
        }
        public IActionResult AccountContact()
        {
            return View();
        }
        public IActionResult AccountEdit()
        {
            return View();
        }
    }
}
