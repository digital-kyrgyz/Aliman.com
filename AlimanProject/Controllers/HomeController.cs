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
        HomePages homePages;
        PayPages payPages;

        public HomeController(ILogger<HomeController> logger)
        {
            accountPages = new AccountPages();

            accountPages.Add.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Call.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Chat.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Contact.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Edit.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };
            accountPages.Photo.Button = new ClickedButton { Active = "btn border border-primary text-primary", NotActive = "btn border border-dark" };

            homePages = new HomePages();

            homePages.Album.Button = new ClickedButton { Active = "col-3 border border-primary text-center text-primary text-decoration-none", NotActive = "col-3 border border-dark text-center text-dark text-decoration-none" };
            homePages.Clip.Button = new ClickedButton { Active = "col-3 border border-primary text-center text-primary text-decoration-none", NotActive = "col-3 border border-dark text-center text-dark text-decoration-none" };
            homePages.Concert.Button = new ClickedButton { Active = "col-3 border border-primary text-center text-primary text-decoration-none", NotActive = "col-3 border border-dark text-center text-dark text-decoration-none" };
            homePages.Chanel.Button = new ClickedButton { Active = "col-3 border border-primary text-center text-primary text-decoration-none", NotActive = "col-3 border border-dark text-center text-dark text-decoration-none" };

            payPages = new PayPages();

            payPages.Store.Button = new ClickedButton { Active = "btn btn-sm border border-primary text-primary", NotActive = "btn btn-sm border border-dark" };
            payPages.Movie.Button = new ClickedButton { Active = "btn btn-sm border border-primary text-primary", NotActive = "btn btn-sm border border-dark" };
            payPages.Tv.Button = new ClickedButton { Active = "btn btn-sm border border-primary text-primary", NotActive = "btn btn-sm border border-dark" };
            payPages.Ads.Button = new ClickedButton { Active = "btn btn-sm border border-primary text-primary", NotActive = "btn btn-sm border border-dark" };

            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Album");
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

        // 

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

        // 


        public IActionResult Album()
        {
            homePages.Activate();
            homePages.Album.Activate();
            homePages.Album.Button.Activate();
            return View(homePages);
        }

        public IActionResult Concert()
        {
            homePages.Activate();
            homePages.Concert.Activate();
            homePages.Concert.Button.Activate();
            return View(homePages);
        }

        public IActionResult Clip()
        {
            homePages.Activate();
            homePages.Clip.Activate();
            homePages.Clip.Button.Activate();
            return View(homePages);
        }

        public IActionResult Chanel()
        {
            homePages.Activate();
            homePages.Chanel.Activate();
            homePages.Chanel.Button.Activate();
            return View(homePages);
        }

        // 
        public IActionResult Pay()
        {
            return RedirectToAction("Store");
        }

        public IActionResult Store()
        {
            payPages.Activate();
            payPages.Store.Activate();
            payPages.Store.Button.Activate();
            ViewBag.PayPages = payPages;
            return View("PayStore");
        }

        public IActionResult Movie()
        {
            payPages.Activate();
            payPages.Movie.Activate();
            payPages.Movie.Button.Activate();
            ViewBag.PayPages = payPages;
            return View("PayMovie");

        }
        public IActionResult Tv()
        {
            payPages.Activate();
            payPages.Tv.Activate();
            payPages.Tv.Button.Activate();
            ViewBag.PayPages = payPages;
            return View("PayTv");

        }
        public IActionResult Ads()
        {
            payPages.Activate();
            payPages.Ads.Activate();
            payPages.Ads.Button.Activate();
            ViewBag.PayPages = payPages;
            return View("PayAds");

        }
        public IActionResult AlbumMusic()
        {
            return View();
        }
    }
}
