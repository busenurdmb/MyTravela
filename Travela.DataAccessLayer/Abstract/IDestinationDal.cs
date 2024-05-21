using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        List<object> GetChart();
        int GetDestinationCount();
    }
}
