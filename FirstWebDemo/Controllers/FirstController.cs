using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebDemo.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult select()
        {
            return View();
        }
        public ActionResult delete()
        {
            return View();
        }
    }
}
