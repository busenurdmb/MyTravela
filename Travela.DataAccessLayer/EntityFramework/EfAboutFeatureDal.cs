
using MyTravela.DataAccessLayer.Abstract;
using MyTravela.DataAccessLayer.Context;
using MyTravela.DataAccessLayer.Repositories;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela.DataAccessLayer.EntityFramework
{
    public class EfAboutFeatureDal : GenericRepository<AboutFeatures>, IAboutFeatureDal
    {
        public EfAboutFeatureDal(TravelaContext context) : base(context)
        {
        }
    }
}
