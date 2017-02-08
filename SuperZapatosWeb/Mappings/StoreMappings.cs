using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosModel;
using SuperZapatosWeb.Models;


namespace SuperZapatosWeb.Mappings
{
    public static class StoreMappings
    {
        /// <summary>
        /// Converts entity model to entity
        /// </summary>
        /// <param name="storeModel">entity model</param>
        /// <returns>entity</returns>
        public static Store toEntity(StoreModel storeModel)
        {
            return new Store
            {
                id = storeModel.id,
                name = storeModel.name,
                address = storeModel.address
            };
        }

        /// <summary>
        /// Converts Entity to view entity
        /// </summary>
        /// <param name="store">entity</param>
        /// <returns>entity model</returns>
        public static StoreModel ToViewEntity(Store store)
        {
            return new StoreModel { 
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
        public static List<StoreModel> ToViewEntityList(List<Store> storeList)
        {
            List<StoreModel> stModelList = new List<StoreModel>();

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