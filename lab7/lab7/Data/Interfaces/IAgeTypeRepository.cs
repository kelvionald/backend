using lab7.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data.Interfaces
{
    interface IAgeTypeRepository
    {
        IEnumerable<AgeType> GetAll();
        AgeType Get(int id);
    }
}
