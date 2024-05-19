using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Repositories;
using Travela.DataAccessLayer.Context;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfServiceDal : GenericRepository<Services>, IServiceDal
    {
        public EfServiceDal(TravelaContext context) : base(context)
        {
        }
    }
}
