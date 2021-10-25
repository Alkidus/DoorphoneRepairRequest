using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


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
            List<DomofonSystem> dfSystems = new List<DomofonSystem>();
            foreach(var el in db.DomofonSystems)
            {
                dfSystems.Add(el);
            }
            ViewBag.AllDomofonSystems = new SelectList(dfSystems, "Id", "DomofonSystemType");
            List<DomofonKey> dfKeys = new List<DomofonKey>();
            foreach (var el in db.DomofonKeys)
            {
                dfKeys.Add(el);
            }
            ViewBag.AllDomofonKeys = new SelectList(dfKeys, "Id", "DomofonKeyType");
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

        public async Task<IActionResult> EditAdress(int? id)
        {
            List<DomofonSystem> dfSystems = new List<DomofonSystem>();
            foreach (var el in db.DomofonSystems)
            {
                dfSystems.Add(el);
            }
            ViewBag.AllDomofonSystems = new SelectList(dfSystems, "Id", "DomofonSystemType");
            List<DomofonKey> dfKeys = new List<DomofonKey>();
            foreach (var el in db.DomofonKeys)
            {
                dfKeys.Add(el);
            }
            ViewBag.AllDomofonKeys = new SelectList(dfKeys, "Id", "DomofonKeyType");
            if (id != null)
            {
                Adress adress = await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
                if (adress != null)
                    return View(adress);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditAdress(Adress adress)
        {
            db.Adresses.Update(adress);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("DeleteAdress")]
        public async Task<IActionResult> ConfirmDeleteAdress(int? id)
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
        public async Task<IActionResult> DeleteAdress(int? id)
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
