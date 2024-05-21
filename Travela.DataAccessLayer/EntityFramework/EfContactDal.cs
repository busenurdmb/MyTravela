
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(TravelaContext context) : base(context)
        {
        }

        public int GetContactCount()
        {
            var context = new TravelaContext();
            var value = context.Contact.Count();
            return value;
        }
    }
}
