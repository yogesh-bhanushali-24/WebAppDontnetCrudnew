using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDontnetCrudnew.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
          
        }

        public IActionResult Detail(int id)
        {
            return Ok("Parameter id is---->"+id);
        }
    }
}
