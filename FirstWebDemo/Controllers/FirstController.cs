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
            string ad = "测试";
            string mgs = "查询成功！";
            return View(ad+mgs);
        }
        public ActionResult delete()
        {
            string mgs = "删除成功！";
            return View(mgs);
        }
        //测试同步
        public void Demo()
        {
            var sting = "测试同步";
        }
    }
}
