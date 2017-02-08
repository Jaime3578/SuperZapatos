using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperZapatosModel;

namespace SuperZapatosDomain.DomainOperatios
{
    public interface IArticleOperations
    {
        IEnumerable<Article> GetAll();

        Article FindById(int id);

        int Insert(Article article);

        int Delete(int id);

        int Update(Article article);
    }
}
