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
        DataDbC Enigma = new DataDbC();
        int current_cat = 0;
        
        public HomeController(MobileContext context)
        {
            db = context;//
            
        }
        public IActionResult Index()
        {
            Enigma.PhoneM = db.Phones.ToList();
            Enigma.CategoryM = db.Categories.ToList();
            return View(Enigma);
        }
        public IActionResult GetCategories()
        {
            
            return PartialView(db.Categories.ToList());
        }
        public IActionResult GetPhones()
        {
            return PartialView();
        }
        public IActionResult GetFilteredModel(CategoryC category)//к сожалению, не работает
        {
            current_cat = category.Id;
            return RedirectToPage("Index");
        }
        public IActionResult EditModel(int id)
        {
            PhoneC element = db.Phones.Find(id);
            ViewBag.Name = element.Name;
            ViewBag.Company = element.Company;
            ViewBag.Price = element.Price;
            ViewBag.CategoryId = element.Parent;
            return View();
        }

        [HttpPost]
        public IActionResult EditModel(PhoneC phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry<PhoneC>(phone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult CreateModel()
        {
            PhoneC element = new PhoneC();
            
            ViewBag.Name = element.Name;
            ViewBag.Company = element.Company;
            ViewBag.Price = element.Price;
            ViewBag.CategoryId = element.Parent;
            return PartialView();
        }
        [HttpPost]
        public IActionResult CreateModel(PhoneC phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteModel(int id)
        {
            PhoneC erased = db.Phones.Find(id);
            ViewBag.Name = erased.Name;
            ViewBag.Company = erased.Company;
            ViewBag.Price = erased.Price;
            ViewBag.CategoryId = erased.Parent;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteModel(PhoneC phone)
        {
            PhoneC deleted = db.Phones.Find(phone.Id);
            db.Phones.Remove(deleted);
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
