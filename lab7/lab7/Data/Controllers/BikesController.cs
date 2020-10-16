using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using lab7.Data.Interfaces;
using lab7.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Data.Controllers
{
    public class BikesController : Controller
    {
        private readonly IBikesRepository _bikesRepository;
        
        public BikesController(IBikesRepository bikesRepository)
        {
            _bikesRepository = bikesRepository;
        }
        
        [HttpGet]
        [Route("api/bikes")]
        public JsonResult GetAll()
        {
            return new JsonResult(_bikesRepository.GetAll());
        }

        [HttpGet]
        [Route("api/bike/get/{id:int}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_bikesRepository.Get(id));
        }

        [HttpGet]
        [Route("api/bike/getByFilter")]
        public JsonResult GetByFilter(int? AgeType, int? SpeedNumber)
        {
            Console.WriteLine(AgeType);
            Console.WriteLine(SpeedNumber);
            Expression<Func<Bike, bool>> condition;
            if (AgeType != null && SpeedNumber == null)
            {
                condition = b => (b.AgeTypeId == AgeType);
            }
            else if (AgeType == null && SpeedNumber != null)
            {
                condition = b => (b.SpeedNumber == SpeedNumber);
            }
            else if (AgeType != null && SpeedNumber != null)
            {
                condition = b => (b.SpeedNumber == SpeedNumber && b.AgeTypeId == AgeType);
            }
            else
            {
                condition = b => true;
            }
            return new JsonResult(_bikesRepository.GetByFilter(condition));
        }
    }
}