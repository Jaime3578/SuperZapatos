using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosModel;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Mappings
{
    public static class ArticleServiceMappings
    {
        /// <summary>
        /// Convert Entity model to entity
        /// </summary>
        /// <param name="articleModel">view entity</param>
        /// <returns>entity</returns>
        public static Article toEntity(ArticleServiceModel articleModel)
        {
            return new Article
            {
                id = articleModel.id,
                name = articleModel.name,
                description = articleModel.description,
                price = articleModel.price,
                total_in_shelf = articleModel.total_in_shelf,
                total_in_vault = articleModel.total_in_vault
            };
        }

        /// <summary>
        /// Convert Entity to view entity
        /// </summary>
        /// <param name="article">Entity object</param>
        /// <returns>view entity</returns>
        public static ArticleServiceModel ToViewEntity(Article article)
        {
            return new ArticleServiceModel
            {
                id = article.id,
                name = article.name,
                description = article.description,
                price = article.price,
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
        public static List<ArticleServiceModel> ToViewEntityList(List<Article> articleList)
        {
            List<ArticleServiceModel> articleModelList = new List<ArticleServiceModel>();

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