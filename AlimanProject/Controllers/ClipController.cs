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
    public class ClipController : Controller
    {
        public ClipController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
