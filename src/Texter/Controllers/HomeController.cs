using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texter.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private TexterDbContext db = new TexterDbContext();
        public IActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        //public IActionResult SendMessage()
        //{
        //    return View();
        //}

        public IActionResult SendMessage()
        {
            ViewBag.To = new SelectList(db.Contacts, "Number", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }
    }
}
