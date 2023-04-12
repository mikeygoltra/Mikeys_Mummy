using Mikeys_Mummy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Model.ViewModels
{
    public class MummyViewModel
    {
        public IQueryable<Burialmain> Burialmain { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
