using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Concrete
{

    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _ServicesDal;
        public ServiceManager(IServiceDal ServicesDal)
        {
            _ServicesDal = ServicesDal;
        }
        public void TDelete(int id)
        {
            _ServicesDal.Delete(id);
        }
        public Services TGetById(int id)
        {
            return _ServicesDal.GetById(id);
        }
        public List<Services> TGetListAll()
        {
            return _ServicesDal.GetListAll();
        }
        public void TInsert(Services entity)
        {
            _ServicesDal.Insert(entity);
        }
        public void TUpdate(Services entity)
        {
            _ServicesDal.Update(entity);
        }
    }
}
