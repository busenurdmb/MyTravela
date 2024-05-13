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
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }
        public void TDelete(int id)
        {
           _destinationDal.Delete(id);
        }
        public Destination TGetById(int id)
        {
            return _destinationDal.GetById(id);
        }
        public List<Destination> TGetListAll()
        {
           return _destinationDal.GetListAll(); 
        }
        public void TInsert(Destination entity)
        {
           _destinationDal.Insert(entity);
        }
        public void TUpdate(Destination entity)
        {
           _destinationDal.Update(entity);
        }
    }
}
