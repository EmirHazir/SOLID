using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.WebUI.Models
{
    public class CategoryListModel
    {
       public List<Category> Categories { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}
