using Solid.Services.SSAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.Entities.SSConcrete;
using Solid.Data.SDAbstract;

namespace Solid.Services.SSConcrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
