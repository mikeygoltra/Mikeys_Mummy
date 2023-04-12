using Mikeys_Mummy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mikeys_Mummy.Data
{
    public interface IMummyRepository
    {
        IQueryable<Burialmain> Burialmain { get; }
    }
}
