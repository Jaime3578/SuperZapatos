using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class ServiceResponseStore
    {
        public List<StoreModel> stores { get; set; }
        public string success { get; set; }
        public int total_elements { get; set; }
    }
}