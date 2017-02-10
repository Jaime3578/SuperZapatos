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
    public class ArticlesController : ApiController
    {
        private readonly IArticleOperations _articleOperations;

        public ArticlesController(IArticleOperations articleOperations)
        {
            _articleOperations = articleOperations;
        }

        /// <summary>
        /// Return all articles stored in db
        /// </summary>
        /// <returns>articles jsonList</returns>
        [BasicHttpAuthorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ArticleServiceModel> articleList = new List<ArticleServiceModel>();

            try
            {
                articleList = ArticleServiceMappings.ToViewEntityList(_articleOperations.GetAll().ToList());

                BadResponse br = BasicOperationsHelper.ValidateRequest("0", articleList.Count());

                if (br != null)
                {
                    return Json(br);
                }

            }
            catch (Exception e)
            {
                return Json(new { error_code = 200, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(200) });
            }

            return Json(new{articles=articleList, succes = true, total_elements = articleList.Count()});
        }
    }
}
