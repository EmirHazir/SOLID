using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.WebUI.Models
{
    public class ProductListModel
    {
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public List<Product> Products { get; set; }
    }
}
