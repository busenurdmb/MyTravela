using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;
using Travela.DataAccessLayer.Context;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EfFeatureDal(TravelaContext context) : base(context)
        {
        }
    }
}
