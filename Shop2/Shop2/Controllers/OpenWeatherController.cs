﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Controllers
{
    public class OpenWeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
