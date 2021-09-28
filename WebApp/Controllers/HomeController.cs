using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        SubscriberContext db;
        public HomeController(SubscriberContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Adresses.ToList());
        }
    }
}
