using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatosDomain.BussinessLogic;
using SuperZapatosModel;
using SuperZapatosModel.UnitOfWork;
using SuperZapatosWeb.Mappings;
using SuperZapatosWeb.Models;
using SuperZapatosDomain.DomainOperatios;

namespace SuperZapatosWeb.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleOperations _articleOperations;
        private readonly IStoreOperations _storeOperations;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleController(IArticleOperations articleOperations, IStoreOperations storeOperations)
        {
            _articleOperations = articleOperations;
            _storeOperations = storeOperations;
        }
        //
        // GET: /Article/
        /// <summary>
        /// Return all articles
        /// </summary>
        /// <returns>article</returns>
        public ActionResult Index()
        {
            List<ArticleModel> articles = ArticleMappings.ToViewEntityList(_articleOperations.GetAll().ToList());
            return View(articles);
        }

        //
        // GET: /Article/Details/5
        /// <summary>
        /// Return detail of store by id
        /// </summary>
        /// <param name="id">id of article</param>
        /// <returns>store object</returns>
        public ActionResult Details(int id)
        {
            ArticleModel store = new ArticleModel();
            store = ArticleMappings.ToViewEntity(_articleOperations.FindById(id));

            return View(store);
        }

        //
        // GET: /Article/Create
        /// <summary>
        /// Creates a new Article
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.stores = _storeOperations.GetAll();
            return View();
        }

        //
        // POST: /Article/Create
        /// <summary>
        /// Creates a new Article
        /// </summary>
        /// <param name="store">article to insert</param>
        /// <returns>view</returns>
        [HttpPost]
        public ActionResult Create(ArticleModel article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _articleOperations.Insert(ArticleMappings.toEntity(article));
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Edit/5
        /// <summary>
        /// Updates an article
        /// </summary>
        /// <param name="id">id of a article</param>
        /// <returns>view</returns>
        public ActionResult Edit(int id)
        {
            ViewBag.stores = _storeOperations.GetAll();
            ArticleModel article = new ArticleModel();
            article = ArticleMappings.ToViewEntity(_articleOperations.FindById(id));
            return View(article);
        }

        //
        // POST: /Article/Edit/5
        /// <summary>
        /// Updates an article
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(ArticleModel article)
        {
            try
            {
                _articleOperations.Update(ArticleMappings.toEntity(article));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Article/Delete/5
        /// <summary>
        /// Delete an article
        /// </summary>
        /// <param name="id">id of article</param>
        /// <returns>view</returns>
        public ActionResult Delete(int id)
        {
            ArticleModel article = new ArticleModel();
            article = ArticleMappings.ToViewEntity(_articleOperations.FindById(id));
            return View(article);
        }

        //
        // POST: /Article/Delete/5
        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(ArticleModel article)
        {
            try
            {
                _articleOperations.Delete(article.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
