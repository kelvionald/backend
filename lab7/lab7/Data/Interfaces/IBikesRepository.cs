using lab7.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lab7.Data.Interfaces
{
    public interface IBikesRepository
    {
        IEnumerable<Bike> GetAll();
        Bike Get(int id);
        IEnumerable<Bike> GetByFilter(Expression<Func<Bike, bool>> condition);
        int Create(Bike bike);
    }
}
