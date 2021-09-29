using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

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
            //var adresses = db.Adresses.Include(systemtype => systemtype.DomofonSystem);
            var adresses = db.Adresses.Include(domofonkey => domofonkey.DomofonKey).Include(systemtype => systemtype.DomofonSystem);
            return View(adresses.ToList());
        }
    }
}
