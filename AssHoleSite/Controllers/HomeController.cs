using AssHoleSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssHoleSite.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;//наша бд с таблицами
        public HomeController(MobileContext context)
        {
            db = context;//
        }

        public IActionResult Index()
        {
            DataDbC Enigma = new DataDbC { PhoneM = db.Phones.ToList(), CategoryM = db.Categories.ToList() };
            return View(Enigma);
        }
        public IActionResult GetCategories()
        {
            return PartialView("GetCategories");
        }
        public IActionResult GetPhones()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            PhoneC element = db.Phones.Find(id);
            ViewBag.Name = element.Name;
            ViewBag.Company = element.Company;
            ViewBag.Price = element.Price;
            ViewBag.CategoryId = element.Parent;
            return View(element);
        }

        [HttpPost]
        public IActionResult Edit(PhoneC phone)
        {
            db.Entry<PhoneC>(phone).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(PhoneC phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
