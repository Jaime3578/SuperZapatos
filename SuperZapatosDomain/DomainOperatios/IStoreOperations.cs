using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperZapatosModel;

namespace SuperZapatosDomain.BussinessLogic
{
    public interface IStoreOperations
    {
         IEnumerable<Store> GetAll();

         Store FindById(int id);

         int Insert(Store store);

         int Delete(int id);

         int Update(Store store);
    }
}
