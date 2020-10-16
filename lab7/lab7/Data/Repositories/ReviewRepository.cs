using lab7.Data.Interfaces;
using lab7.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7.Data.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public int Create(Review review)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Review> GetByBikeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
