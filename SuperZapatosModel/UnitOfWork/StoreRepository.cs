using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public class StoreRepository : SZRepository<Store>, IStoreRepository
    {
        public StoreRepository(DbContext context) : base(context) { }
    }
}
