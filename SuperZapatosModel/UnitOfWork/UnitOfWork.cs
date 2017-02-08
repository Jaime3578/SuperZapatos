using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SuperZapatosContext DbContext { get; set; }
 
        public UnitOfWork()
        {
            CreateDbContext();
        }
 
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public IArticleRepository Articles
        {
            get { return new ArticleRepository(DbContext); }
        }

        public IStoreRepository Stores
        {
            get { return new StoreRepository(DbContext); }
        }
 
        public void Dispose()
        {
            DbContext.Dispose();
        }
 
        public void CreateDbContext()
        {
            DbContext = new SuperZapatosContext();

            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }
    }
}
