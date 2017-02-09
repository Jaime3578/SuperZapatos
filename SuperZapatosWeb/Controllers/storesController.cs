using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using SuperZapatosDomain.BussinessLogic;
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
        private readonly IUnitOfWork _unitOfWork;

        public storesController(IStoreOperations storeOperations)
        {
            _storeOperations = storeOperations;
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
        [Route("services/articles/stores/{id}")]
        [HttpGet]
        public Object GetArticlesByStore(string id)
        {
            return "perro hdp";
        }
    }
}
