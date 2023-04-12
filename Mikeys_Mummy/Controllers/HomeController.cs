using Microsoft.AspNetCore.Mvc;
using Mikeys_Mummy.Data;
using Mikeys_Mummy.ViewModels;
using Mikeys_Mummy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Controllers
{
    public class HomeController : Controller
    {
        private IMummyRepository repo;

        public HomeController(IMummyRepository temp)
        {
            repo = temp;
        }
        public IActionResult Dashboard(string bodySex, int pageNum = 1)
        {
            int pageSize = 5;

            //we have two models we are using so if we need to pass data to both, do it here
            var passInfo = new MummyViewModel
            {
                BurialMain = repo.BurialMain
                .Where(b => b.Sex == bodySex || bodySex == null)
                .OrderBy(b => b.Area)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),


                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                        (bodySex == null ?
                            repo.BurialMain.Count()
                            : repo.BurialMain.Where(x => x.Sex == bodySex).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(passInfo);
        }

        public IActionResult InfoPage(int burid)
        {

            Burialmain burialmain = repo.BurialMain.FirstOrDefault(a => a.Id == burid);
            if (burialmain == null)
            {
                return NotFound();
            }
            return View(burialmain);
        }

        public IActionResult Unsupervised()
        {
            return View();
        }
         
    }
}
