using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDontnetCrudnew.Data;
using WebAppDontnetCrudnew.Models;

namespace WebAppDontnetCrudnew.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDBContext _db;


        public ExpenseController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
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
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);   
        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
     
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
