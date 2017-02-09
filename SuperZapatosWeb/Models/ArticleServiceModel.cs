using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class ArticleServiceModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int total_in_shelf { get; set; }
        public int total_in_vault { get; set; }
        public string storeName { get; set; }
    }
}