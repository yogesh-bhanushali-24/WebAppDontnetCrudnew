using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDontnetCrudnew.Models;
using WebAppDontnetCrudnew.Data;

namespace WebAppDontnetCrudnew.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDBContext _db;
       

        public ItemController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }

        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
