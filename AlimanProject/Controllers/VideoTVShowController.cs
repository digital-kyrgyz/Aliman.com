﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlimanProject.Controllers
{
    public class VideoTVShowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
