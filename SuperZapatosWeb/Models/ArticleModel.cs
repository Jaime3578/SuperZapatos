using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SuperZapatosModel;

namespace SuperZapatosWeb.Models
{
    public class ArticleModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Display(Name = "Descripción")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Precio")]
        [Range(0, float.MaxValue, ErrorMessage = "Debe ser númerico!")]
        public float price { get; set; }
        [Required]
        [Display(Name = "Total en estantería")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser númerico!")]
        public int total_in_shelf { get; set; }
        [Required]
        [Display(Name = "Total en bodega")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser númerico!")]
        public int total_in_vault { get; set; }
        [Display(Name = "Tienda")]
        public string storeName { get; set; }
        public IEnumerable<Store> storeList { get; set; }
        public int storeId { get; set; }
    }
}