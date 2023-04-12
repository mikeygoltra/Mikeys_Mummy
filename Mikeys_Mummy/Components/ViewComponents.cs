using Microsoft.AspNetCore.Mvc;
using Mikeys_Mummy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Components
{
    public class ViewComponents : ViewComponent
    {
        private IMummyRepository repo { get; set; } //pulling in the data from repo (because the context is called in the repo)

        public ViewComponents(IMummyRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedSex = RouteData?.Values["bodySex"];

            var sex = repo.BurialMain
                .Select(x => x.Sex)
                .Distinct()
                .OrderBy(x => x);

            return View(sex);
        }
    }
    public class HeadDirectionViewComponent : ViewComponent
    {

        private IMummyRepository repo { get; set; } //pulling in the data from repo (because the context is called in the repo)

        public HeadDirectionViewComponent(IMummyRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedHeaDir = RouteData?.Values["bodyHeadDir"];

            var head = repo.BurialMain
                .Select(x => x.Headdirection)
                .Distinct()
                .OrderBy(x => x);

            return View(head); // try with 2 filters at first
        }

    }
}
