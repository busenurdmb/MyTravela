using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTravela.BusinessLayer.Abstract;
using MyTravela.DataAccessLayer.Abstract;
using MyTravela.EntityLayer.Concrete;

namespace MyTravela.BusinessLayer.Concrete
{
   public class AboutManager : IAboutService
    {
        private readonly IAboutDal _AboutDal;
        public AboutManager(IAboutDal AboutDal)
        {
            _AboutDal = AboutDal;
        }
        public void TDelete(int id)
        {
            _AboutDal.Delete(id);
        }
        public About TGetById(int id)
        {
            return _AboutDal.GetById(id);
        }
        public List<About> TGetListAll()
        {
            return _AboutDal.GetListAll();
        }
        public void TInsert(About entity)
        {
            _AboutDal.Insert(entity);
        }
        public void TUpdate(About entity)
        {
            _AboutDal.Update(entity);
        }
    }
}
