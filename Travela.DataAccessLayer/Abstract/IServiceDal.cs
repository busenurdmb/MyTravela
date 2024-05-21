using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Abstract
{
    public interface IServiceDal : IGenericDal<Services>
    {
        int GetServiceCount();
    }
}
