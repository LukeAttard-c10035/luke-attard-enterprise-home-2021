﻿using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class FileTransferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
