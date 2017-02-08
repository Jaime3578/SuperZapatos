using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel
{
    public class Article
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int total_in_shelf { get; set; }
        public int total_in_vault { get; set; }
        public int store_id { get; set; }
        public virtual Store store { get; set; }
    }
}
