using System;
using System.Collections.Generic;
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
    public class storesController : ApiController
    {
        private readonly IStoreOperations _storeOperations;
        private readonly IArticleOperations _articleOperations;
        private readonly IUnitOfWork _unitOfWork;

        public storesController(IStoreOperations storeOperations, IArticleOperations articleOperations)
        {
            _storeOperations = storeOperations;
            _articleOperations = articleOperations;
        }

        [BasicHttpAuthorize]
        [HttpGet]
        public Object Get()
        {
            ServiceResponseStore srs = new ServiceResponseStore();
            List<StoreModel> storeList = new List<StoreModel>();

            try
            {
                storeList = StoreMappings.ToViewEntityList(_storeOperations.GetAll().ToList());
                srs.stores = storeList;
                srs.success = "true";
                srs.total_elements = storeList.Count();
            }
            catch (Exception e)
            {
                return Json(new BadResponse { error_code = 200, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(200) });
            }

            return Json(srs);
        }

        [BasicHttpAuthorize]
        [HttpGet]
        public Object GetArticlesByStore(string id)
        {
            int n;
            bool isNumeric = int.TryParse(id, out n);
            List<ArticleServiceModel> artList = new List<ArticleServiceModel>();
            ServiceResponseArticle sra = new ServiceResponseArticle();

            try{
                 if (!isNumeric)
                {
                    return Json(new BadResponse { error_code = 400, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(400) });
                }

                artList = ArticleServiceMappings.ToViewEntityList(_articleOperations.GetArticlesByStore(n).ToList());
                n = artList.Count();
           
                if (n <= 0)
                {
                    return Json(new BadResponse { error_code = 404, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(404) });
                }



            }catch (Exception e)
            {
                return Json(new BadResponse { error_code = 200, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(200) });
            }

            return
        }
    }
}
