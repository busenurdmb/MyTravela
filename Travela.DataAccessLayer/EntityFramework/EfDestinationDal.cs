using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public EfDestinationDal(TravelaContext context) : base(context)
        {
          
        }
        public List<object> GetChart()
        {
            var context = new TravelaContext();
            var query = from destination in context.Destinations
                        join category in context.Categories
                        on destination.CategoryId equals category.CategoryId
                        group category by category.CategoryName into g
                        select new
                        {
                            CategoryName = g.Key,
                            DestinationCount = g.Count()
                        };

            return query.ToList<object>();
        }
        public int GetDestinationCount()
        {
            var context = new TravelaContext();
            var value = context.Destinations.Count();
            return value;
        }
    }
}
