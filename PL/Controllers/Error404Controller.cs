﻿using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Error404Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
