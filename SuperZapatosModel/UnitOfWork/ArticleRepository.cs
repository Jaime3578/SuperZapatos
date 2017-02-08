using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel.UnitOfWork
{
    public class  ArticleRepository : SZRepository<Article>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context) { }
    }
}
