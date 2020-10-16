using lab7.Data.Interfaces;
using lab7.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace lab7.Data.Repositories
{
    public class BikesRepository : IBikesRepository
    {
        private readonly AppDbContext _appDbContext;
        public BikesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int Create(Bike bike)
        {
            throw new NotImplementedException();
        }

        public Bike Get(int id)
        {
            object[] ids = {id};
            return _appDbContext.Bikes.Find(ids);
        }

        public IEnumerable<Bike> GetAll()
        {
            return _appDbContext.Bikes.ToList();
        }

        public IEnumerable<Bike> GetByFilter(Expression<Func<Bike, bool>> condition)
        {
            return _appDbContext.Bikes.Where(condition).ToList();
        }
    }
}
