using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Concrete
{
    public class GaleryManager : IGaleryService
    {
        private readonly IGaleryDal _GaleryDal;
        public GaleryManager(IGaleryDal GaleryDal)
        {
            _GaleryDal = GaleryDal;
        }
        public void TDelete(int id)
        {
            _GaleryDal.Delete(id);
        }
        public Galery TGetById(int id)
        {
            return _GaleryDal.GetById(id);
        }
        public List<Galery> TGetListAll()
        {
            return _GaleryDal.GetListAll();
        }
        public void TInsert(Galery entity)
        {
            _GaleryDal.Insert(entity);
        }
        public void TUpdate(Galery entity)
        {
            _GaleryDal.Update(entity);
        }
    }
}

