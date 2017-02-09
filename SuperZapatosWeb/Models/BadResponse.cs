using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class BadResponse
    {
        public string success { get; set; }
        public int error_code { get; set; }
        public string error_msg { get; set; }
    }
}