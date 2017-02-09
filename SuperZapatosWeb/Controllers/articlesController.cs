using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuperZapatosDomain.DomainOperatios;
using SuperZapatosModel.UnitOfWork;
using SuperZapatosWeb.Helpers;
using SuperZapatosWeb.Mappings;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Controllers
{
    public class articlesController : ApiController
    {
        private readonly IArticleOperations _articleOperations;

        public articlesController(IArticleOperations articleOperations)
        {
            _articleOperations = articleOperations;
        }

        [BasicHttpAuthorize]
        [HttpGet]
        public Object Get()
        {
            ServiceResponseArticle sra = new ServiceResponseArticle();
            List<ArticleServiceModel> articleList = new List<ArticleServiceModel>();

            try
            {
                articleList = ArticleServiceMappings.ToViewEntityList(_articleOperations.GetAll().ToList());
                sra.articles = articleList;
                sra.success = "true";
                sra.total_elements = articleList.Count();
            }
            catch (Exception e)
            {
                return Json(new BadResponse { error_code = 200, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(200) });
            }

            return Json(sra);
        }
    }
}
