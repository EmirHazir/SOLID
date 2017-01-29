using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Services.SSAbstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
