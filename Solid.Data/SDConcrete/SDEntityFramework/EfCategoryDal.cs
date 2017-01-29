using Solid.Core.SCDataAccess.SCEntityFramework;
using Solid.Data.SDAbstract;
using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Data.SDConcrete.SDEntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
