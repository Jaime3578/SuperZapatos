using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosModel;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Mappings
{
    public static class ArticleMappings
    {
        /// <summary>
        /// Convert Entity model to entity
        /// </summary>
        /// <param name="articleModel">view entity</param>
        /// <returns>entity</returns>
        public static Article toEntity(ArticleModel articleModel)
        {
            return new Article
            {
                id = articleModel.id,
                name = articleModel.name,
                description = articleModel.description,
                price = articleModel.price,
                store_id = articleModel.storeId,
                total_in_shelf = articleModel.total_in_shelf,
                total_in_vault = articleModel.total_in_vault
            };
        }
    
        /// <summary>
        /// Convert Entity to view entity
        /// </summary>
        /// <param name="article">Entity object</param>
        /// <returns>view entity</returns>
        public static ArticleModel ToViewEntity(Article article)
        {
            return new ArticleModel
            {
                id = article.id,
                name = article.name,
                description = article.description,
                price = article.price,
                storeId = article.store_id,
                total_in_shelf = article.total_in_shelf,
                total_in_vault = article.total_in_vault,
                storeName = article.store != null ? article.store.name : ""
            };
        }

        /// <summary>
        /// map entity to view entity model
        /// </summary>
        /// <param name="articleList">list of article entity</param>
        /// <returns>list of article view model</returns>
        public static List<ArticleModel> ToViewEntityList(List<Article> articleList)
        {
            List<ArticleModel> articleModelList = new List<ArticleModel>();

            if (articleList.Count > 0)
            {
                foreach (Article a in articleList)
                {
                    articleModelList.Add(ToViewEntity(a));
                }
            }

            return articleModelList;
        }
    }
}