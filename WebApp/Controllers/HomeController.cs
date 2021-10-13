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
        public IActionResult AddAdress()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await db.Adresses.Include(domofonkey => 
            domofonkey.DomofonKey).Include(systemtype => 
            systemtype.DomofonSystem).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddAdress(Adress adress)
        {
            db.Adresses.Add(adress);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Adress adress = await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
                if (adress != null)
                    return View(adress);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Adress adress)
        {
            db.Adresses.Update(adress);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Adress adress = await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
                if (adress != null)
                    return View(adress);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Adress adress = await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
                if (adress != null)
                {
                    db.Adresses.Remove(adress);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }




   
    }
}
