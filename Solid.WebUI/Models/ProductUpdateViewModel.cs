using System.Collections.Generic;
using Solid.Entities.SSConcrete;

namespace Solid.WebUI.Models
{
    public class ProductUpdateViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}