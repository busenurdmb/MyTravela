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
    public class ContactManager:IContactService
    {
        private readonly IContactDal _ContactDal;
        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }
        public void TDelete(int id)
        {
            _ContactDal.Delete(id);
        }
        public Contact TGetById(int id)
        {
            return _ContactDal.GetById(id);
        }
        public List<Contact> TGetListAll()
        {
            return _ContactDal.GetListAll();
        }
        public void TInsert(Contact entity)
        {
            _ContactDal.Insert(entity);
        }
        public void TUpdate(Contact entity)
        {
            _ContactDal.Update(entity);
        }
    }
}
