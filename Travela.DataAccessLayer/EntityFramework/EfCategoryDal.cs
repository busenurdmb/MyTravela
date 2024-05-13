using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTravela.DataAccessLayer.Abstract;
using MyTravela.DataAccessLayer.Context;
using MyTravela.DataAccessLayer.Repositories;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(TravelaContext context) : base(context)
        {

        }

        public int GetCategoryCount()
        {
            var context = new TravelaContext();
            var value = context.Categories.Count();
            return value;
        }
    }
}