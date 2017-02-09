using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class ServiceResponseArticle
    {
        public List<ArticleServiceModel> articles { get; set; }
        public string success { get; set; }
        public int total_elements { get; set; }
    }
}