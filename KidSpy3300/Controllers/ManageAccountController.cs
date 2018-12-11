using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KidSpy3300.Models;

namespace KidSpy3300.Controllers
{
    public class ManageAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
