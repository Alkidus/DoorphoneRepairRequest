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
using WebApp.Repository;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        //IRepository<Adress> adressRepository;
        //IRepository<DomofonKey> domofonKeyRepository;
        //IRepository<DomofonSystem> domofonSystemRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();
        //SubscriberContext db;
        //public HomeController(SubscriberContext context)
        //{
        //    db = context;
        //}
        //public HomeController()
        //{
        //    adressRepository = new AdressRepository(new SubscriberContext());
        //    domofonKeyRepository = new DomofonKeyRepository(new SubscriberContext());
        //    domofonSystemRepository = new DomofonSystemRepository(new SubscriberContext());
        //}
        //public HomeController(IRepository<Adress> adressRepository, IRepository<DomofonKey> domofonKeyRepository, IRepository<DomofonSystem> domofonSystemRepository)
        //{
        //    this.adressRepository = adressRepository;
        //    this.domofonKeyRepository = domofonKeyRepository;
        //    this.domofonSystemRepository = domofonSystemRepository;
        //}
        //public HomeController(IRepository<DomofonKey> domofonKeyRepository)
        //{
        //    this.domofonKeyRepository = domofonKeyRepository;
        //}
        //public HomeController(IRepository<DomofonSystem> domofonSystemRepository)
        //{
        //    this.domofonSystemRepository = domofonSystemRepository;
        //}
        //public IActionResult AddAdress()
        //{
        //    List<DomofonSystem> dfSystems = new List<DomofonSystem>();
        //    foreach(var el in db.DomofonSystems)
        //    {
        //        dfSystems.Add(el);
        //    }
        //    ViewBag.AllDomofonSystems = new SelectList(dfSystems, "Id", "DomofonSystemType");
        //    List<DomofonKey> dfKeys = new List<DomofonKey>();
        //    foreach (var el in db.DomofonKeys)
        //    {
        //        dfKeys.Add(el);
        //    }
        //    ViewBag.AllDomofonKeys = new SelectList(dfKeys, "Id", "DomofonKeyType");
        //    return View();
        //}
        [HttpGet]
        public ActionResult Index()
        {
            //return View(await db.Adresses.Include(domofonkey =>
            //domofonkey.DomofonKey).Include(systemtype =>
            //systemtype.DomofonSystem).ToListAsync());
            //AdressRepository ar = new AdressRepository(new SubscriberContext()); //попытаться создать напрямую
            //ar.GetAllAdressToIndex();
            //return View(adressRepository.GetAllList());
            return View(unitOfWork.AdressRepository.GetAllList());
        }
        [HttpPost]
        public ActionResult AddAdress(Adress adress)
        {
            unitOfWork.AdressRepository.Create(adress);
            unitOfWork.Save();
            //adressRepository.Create(adress);
            //adressRepository.Save();
            //db.Adresses.Add(adress);
            //await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult EditAdress(int id)
        {
            List<DomofonSystem> dfSystems = new List<DomofonSystem>();
            //foreach (var el in domofonSystemRepository.GetAllList())
            foreach (var el in unitOfWork.DomofonSystemRepository.GetAllList())
            {
                dfSystems.Add(el);
            }
            ViewBag.AllDomofonSystems = new SelectList(dfSystems, "Id", "DomofonSystemType");
            List<DomofonKey> dfKeys = new List<DomofonKey>();
            //foreach (var el in domofonKeyRepository.GetAllList())
            foreach (var el in unitOfWork.DomofonKeyRepository.GetAllList())
            {
                dfKeys.Add(el);
            }
            ViewBag.AllDomofonKeys = new SelectList(dfKeys, "Id", "DomofonKeyType");
            //if (id != null)
            //{
            Adress adress = unitOfWork.AdressRepository.GetByID(id);/*Adress adress = adressRepository.GetByID(id);*/ // db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
            if (adress != null)
                return View(adress);
            else
                return NotFound();
            //}
            //return NotFound();
        }
        [HttpPost]
        public ActionResult EditAdress(Adress adress)
        {
            //db.Adresses.Update(adress);
            //db.SaveChangesAsync();
            //adressRepository.Edit(adress);
            //adressRepository.Save();
            unitOfWork.AdressRepository.Edit(adress);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("DeleteAdress")]
        public IActionResult ConfirmDeleteAdress(int id)
        {
            //if (id != null)
            //{
            Adress adress = unitOfWork.AdressRepository.GetByID(id);/*Adress adress = adressRepository.GetByID(id);*///await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
            if (adress != null)
                return View(adress);
            //}
            return NotFound();
        }

        [HttpPost]
        public ActionResult DeleteAdress(int id)
        {
            //if (id != null)
            //{
            //Adress adress = adressRepository.GetByID(id);//await db.Adresses.FirstOrDefaultAsync(p => p.Id == id);
            //if (adress != null)
            //{
                unitOfWork.AdressRepository.Delete(id);
                unitOfWork.Save();
                //adressRepository.Delete(id);
                //adressRepository.Save();
                //db.Adresses.Remove(adress);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            //}
            //}
            //return NotFound();
        }




    }
}
