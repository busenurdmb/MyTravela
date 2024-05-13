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
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public EfDestinationDal(TravelaContext context) : base(context)
        {
        }
    }
}
