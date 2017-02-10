using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using SuperZapatosDomain.BussinessLogic;
using SuperZapatosDomain.DomainOperatios;
using SuperZapatosModel;
using SuperZapatosModel.UnitOfWork;
using SuperZapatosWeb.Helpers;
using SuperZapatosWeb.Mappings;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Controllers
{
    public class StoresController : ApiController
    {
        private readonly IStoreOperations _storeOperations;
        private readonly IArticleOperations _articleOperations;

        public StoresController(IStoreOperations storeOperations, IArticleOperations articleOperations)
        {
            _storeOperations = storeOperations;
            _articleOperations = articleOperations;
        }

        /// <summary>
        /// Return all stores in json format
        /// </summary>
        /// <returns>stores in json format</returns>
        [BasicHttpAuthorize]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<StoreServiceModel> storeList = new List<StoreServiceModel>();

            try
            {
                storeList = StoreServiceMappings.ToViewEntityList(_storeOperations.GetAll().ToList());

                BadResponse br = BasicOperationsHelper.ValidateRequest("0", storeList.Count());

                if (br != null)
                {
                    return Json(br);
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.StackTrace);
                return Json(new { stores = storeList, succes = true, total_elements = storeList.Count() });
            }

            return Json(new { stores = storeList, succes = true, total_elements = storeList.Count() });
        }

        /// <summary>
        /// Return all articles from a store
        /// </summary>
        /// <param name="id">id of store</param>
        /// <returns>list of articles</returns>
        [BasicHttpAuthorize]
        [HttpGet]
        public IHttpActionResult GetArticlesByStore(string id)
        {
            int n;
            bool isNumeric = int.TryParse(id, out n);

            List<ArticleServiceModel> artList = new List<ArticleServiceModel>();

            try{

                artList = ArticleServiceMappings.ToViewEntityList(_articleOperations.GetArticlesByStore(n).ToList());
                BadResponse br = BasicOperationsHelper.ValidateRequest(id, artList.Count());

                if (br != null)
                {
                    return Json(br);
                }

            }catch (Exception e)
            {
                Trace.TraceError(e.StackTrace);
                return Json(new { error_code = 200, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(200) });
            }

            return Json(new { articles = artList, succes = true, total_elements = artList.Count() });
        }
    }
}
