using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public interface IUnitOfWork
    {
        int Commit();
        IArticleRepository Articles { get; }
        IStoreRepository Stores { get; }
    }
}
