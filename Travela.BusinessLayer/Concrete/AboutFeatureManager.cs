using MyTravela.BusinessLayer.Abstract;
using MyTravela.DataAccessLayer.Abstract;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela .BusinessLayer.Concrete
{
    
    public class AboutFeatureManager : IAboutFeatureSevice
    {
        private readonly IAboutFeatureDal _AboutFeatureDal;
        public AboutFeatureManager(IAboutFeatureDal AboutFeatureDal)
        {
            _AboutFeatureDal = AboutFeatureDal;
        }
        public void TDelete(int id)
        {
            _AboutFeatureDal.Delete(id);
        }
        public AboutFeatures TGetById(int id)
        {
            return _AboutFeatureDal.GetById(id);
        }
        public List<AboutFeatures> TGetListAll()
        {
            return _AboutFeatureDal.GetListAll();
        }
        public void TInsert(AboutFeatures entity)
        {
            _AboutFeatureDal.Insert(entity);
        }
        public void TUpdate(AboutFeatures entity)
        {
            _AboutFeatureDal.Update(entity);
        }
    }
}
