using Mikeys_Mummy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Data
{
    public class EFMummyRepository : IMummyRepository
    {
        private intex2dbContext context { get; set; }
        public EFMummyRepository(intex2dbContext temp)
        {
            context = temp;
        }
        public IQueryable<Burialmain> BurialMain => context.BurialMain;


    }
}
