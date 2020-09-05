using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlimanProject.Models;
using AlimanProject.ExtraClasses;

namespace AlimanProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AccountPages accountPages;
        

        public HomeController(ILogger<HomeController> logger)
        {
            accountPages = new AccountPages();

            accountPages.Add.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Call.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Chat.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Contact.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Edit.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Photo.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            
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
            
            accountPages.Chat.Button.Activate();
            
            return View(accountPages);
        }
        public IActionResult AccountContact()
        {
            accountPages.Contact.Button.Activate();

            return View(accountPages);
        }
        public IActionResult AccountEdit()
        {
            accountPages.Edit.Button.Activate();

            return View(accountPages);
        }
        public IActionResult AccountCalls()
        {
            accountPages.Call.Button.Activate();

            return View(accountPages);
        }
        public IActionResult AccountAdd()
        {
            accountPages.Add.Button.Activate();

            return View(accountPages);
        }
        public IActionResult AccountPhotos()
        {
            accountPages.Photo.Button.Activate();

            return View(accountPages);
        }
        public IActionResult MenuBar()
        {
            return View();
        }
    }
}
