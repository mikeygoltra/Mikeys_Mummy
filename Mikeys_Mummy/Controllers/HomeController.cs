using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Controllers
{
    public class HomeController : Controller
    {

        //Here all the actions of the Views will be created
        public IActionResult Index()
        {
            return View();
        }
    }
}
