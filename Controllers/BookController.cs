﻿using Microsoft.AspNetCore.Mvc;

namespace PRN222_DreamsCar.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
