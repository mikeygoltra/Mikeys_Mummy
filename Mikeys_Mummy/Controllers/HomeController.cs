using Microsoft.AspNetCore.Mvc;
using Mikeys_Mummy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Controllers
{
    public class HomeController : Controller
    {
        private intex2dbContext context { get; set; }

        public HomeController(intex2dbContext temp) => context = temp;
        //Here all the actions of the Views will be created
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Unsupervised()
        {
            return View();
        }
         
    }
}
