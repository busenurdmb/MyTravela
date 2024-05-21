using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;
using Travela.BusinessLayer.Abstract;
using Travela.DataAccessLayer.Abstract;

namespace Travela.BusinessLayer.Concrete
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

        public List<object> TGetChart()
        {
            return _destinationDal.GetChart();
        }

        public int TGetDestinationCount()
        {
            return _destinationDal.GetDestinationCount();
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
