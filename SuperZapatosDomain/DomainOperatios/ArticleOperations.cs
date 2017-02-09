using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperZapatosDomain.DomainOperatios;
using SuperZapatosModel;
using SuperZapatosModel.UnitOfWork;

namespace SuperZapatosDomain.BussinessLogic
{

    public class ArticleOperations : IArticleOperations
    {
        private IUnitOfWork _unitOfWork;

        public ArticleOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Article> GetAll()
        {
            Article a = new Article();
            List<Article> articleList= _unitOfWork.Articles.GetAll().ToList();

            for (int i = 0; i < articleList.Count(); i++)
            {
                articleList[i].store = _unitOfWork.Stores.GetById(articleList[i].store_id);
            }

            return articleList;

        }

        public IEnumerable<Article> GetArticlesByStore(int id)
        {
            return GetAll().Where(x => x.store_id == id);
        }

        public Article FindById(int id)
        {
            Article article = new Article();
            article = _unitOfWork.Articles.GetById(id);

            if (article != null)
            {
                article.store = _unitOfWork.Stores.GetById(article.store_id);
            }

            return article;
        }

        public int Insert(Article article)
        {
            _unitOfWork.Articles.Insert(article);
            return _unitOfWork.Commit();
        }

        public int Delete(int id)
        {
            Article article = _unitOfWork.Articles.GetById(id);
            _unitOfWork.Articles.Delete(article);
            return _unitOfWork.Commit();
        }

        public int Update(Article article)
        {
            _unitOfWork.Articles.Update(article);
            return _unitOfWork.Commit();
        }
    }
}
