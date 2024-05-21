using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfGaleryDal : GenericRepository<Galery>, IGaleryDal
    {
        public EfGaleryDal(TravelaContext context) : base(context)
        {
        }
    }
}
