using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosModel
{
    public class Store
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public virtual ICollection<Article> article { get; set; }
    }
}
