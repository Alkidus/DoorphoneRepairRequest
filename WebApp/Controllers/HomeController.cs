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
            SelectList dfSystems = new SelectList(db.DomofonSystems, "DomofonSystemType", "_Name");
            ViewBag.AllDomofonSystems = dfSystems;
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
        //IList<Student> studentList = new List<Student>() {
        //            new Student(){ StudentID=1, StudentName="Steve", Age = 21 },
        //            new Student(){ StudentID=2, StudentName="Bill", Age = 25 },
        //            new Student(){ StudentID=3, StudentName="Ram", Age = 20 },
        //            new Student(){ StudentID=4, StudentName="Ron", Age = 31 },
        //            new Student(){ StudentID=5, StudentName="Rob", Age = 19 }
        //        };
        //// GET: Student
        //public ActionResult Index()
        //{
        //    ViewBag.TotalStudents = studentList.Count();

        //    return View();
        //}
        //IList<DomofonSystem> domofonSystemsList = new List<DomofonSystem>();
        //public async Task<IActionResult> GetAllDomofonSystems()
        //{

        //}



    }
}
