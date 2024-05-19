using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;
using Travela.DataAccessLayer.Context;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfAboutFeatureDal : GenericRepository<AboutFeatures>, IAboutFeatureDal
    {
        public EfAboutFeatureDal(TravelaContext context) : base(context)
        {
        }
    }
}
