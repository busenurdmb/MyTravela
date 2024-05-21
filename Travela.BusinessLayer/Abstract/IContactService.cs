using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;

namespace Travela.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
        public int TGetContactCount();
    }
}
