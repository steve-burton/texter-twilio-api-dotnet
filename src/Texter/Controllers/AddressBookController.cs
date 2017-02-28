using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Texter.Models;
using Microsoft.EntityFrameworkCore;


namespace Texter.Controllers
{
    public class AddressBookController : Controller
    {
        // GET: /<controller>/
        private TexterDbContext db = new TexterDbContext();
        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
