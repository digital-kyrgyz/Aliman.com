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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
        
        public IActionResult AccountChat()
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
        public IActionResult AccountCalls()
        {
            return View();
        }
        public IActionResult AccountAdd()
        {
            return View();
        }
        public IActionResult AccountPhotos()
        {
            return View();
        }
        public IActionResult MenuBar()
        {
            return View();
        }
    }
}
