using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosModel;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Mappings
{
    public static class StoreServiceMappings
    {
        /// <summary>
        /// Converts entity model to entity
        /// </summary>
        /// <param name="StoreServiceModel">entity model</param>
        /// <returns>entity</returns>
        public static Store toEntity(StoreServiceModel StoreServiceModel)
        {
            return new Store
            {
                id = StoreServiceModel.id,
                name = StoreServiceModel.name,
                address = StoreServiceModel.address
            };
        }

        /// <summary>
        /// Converts Entity to view entity
        /// </summary>
        /// <param name="store">entity</param>
        /// <returns>entity model</returns>
        public static StoreServiceModel ToViewEntity(Store store)
        {
            return new StoreServiceModel
            {
                id = store.id,
                name = store.name,
                address = store.address
            };
        }

        /// <summary>
        /// Converts entity list to list entity model
        /// </summary>
        /// <param name="storeList">list of entities</param>
        /// <returns>list entity model</returns>
        public static List<StoreServiceModel> ToViewEntityList(List<Store> storeList)
        {
            List<StoreServiceModel> stModelList = new List<StoreServiceModel>();

            if (storeList.Count > 0)
            {
                foreach (Store s in storeList)
                {
                    stModelList.Add(ToViewEntity(s));
                }
            }

            return stModelList;
        }
    }
}