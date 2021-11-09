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
        IRepository<Adress> adressRepository;

        public HomeController(IRepository<Adress> repository)
        {
            //this.adressRepository = new AdressRepository(new SubscriberContext());
            adressRepository = repository;

        }

        public IActionResult IndexHello()
        {
            ViewData["Message"] = "Hello world!";
            return View("IndexHello");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(adressRepository.GetAllList());
        }
        [HttpPost]
        public ActionResult AddAdress(Adress adress)
        {
            if (ModelState.IsValid)
            {
                adressRepository.Create(adress);
                adressRepository.Save();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        public ActionResult EditAdressByID(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            Adress adress = adressRepository.GetByID(id.Value);
            if (adress != null)
                return View(adress);
            else
                return NotFound();
        }
        [HttpPost]
        public ActionResult EditAdress(Adress adress)
        {
            adressRepository.Edit(adress);
            adressRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [ActionName("DeleteAdress")]
        public IActionResult ConfirmDeleteAdress(int id)
        {
            Adress adress = adressRepository.GetByID(id);
                if (adress != null)
                    return View(adress);
                else
                    return NotFound();
        }

        [HttpPost]
        public ActionResult DeleteAdress(int id)
        {
            Adress adress = adressRepository.GetByID(id);
            adressRepository.Delete(id);
            adressRepository.Save();
            return RedirectToAction("Index");
        }




    }
}
