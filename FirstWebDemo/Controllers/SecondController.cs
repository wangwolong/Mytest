using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebDemo.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            //测试
            return View();
        }
    }
}
