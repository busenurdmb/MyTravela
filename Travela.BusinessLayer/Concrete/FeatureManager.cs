using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.BusinessLayer.Abstract;

namespace Travela.BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _FeatureDal;
        public FeatureManager(IFeatureDal FeatureDal)
        {
            _FeatureDal = FeatureDal;
        }
        public void TDelete(int id)
        {
            _FeatureDal.Delete(id);
        }
        public Feature TGetById(int id)
        {
            return _FeatureDal.GetById(id);
        }
        public List<Feature> TGetListAll()
        {
            return _FeatureDal.GetListAll();
        }
        public void TInsert(Feature entity)
        {
            _FeatureDal.Insert(entity);
        }
        public void TUpdate(Feature entity)
        {
            _FeatureDal.Update(entity);
        }
    }
}
