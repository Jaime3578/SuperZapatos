using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperZapatosWeb.Models
{
    public class StoreModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(40, ErrorMessage = "Nombre no puede sobrepasar 250 caracteres.")]
        public string name { get; set; }
        [Display(Name = "Dirección")]
        public string address { get; set; }
    }
}
