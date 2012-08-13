using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class Catalog
    {
        public int CatalogID { get; set; }
        public int ParentCatalogID { get; set; }
        public string Name { get; set; }
    }
}
