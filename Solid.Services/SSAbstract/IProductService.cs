using Solid.Entities.SSConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.Services.SSAbstract
{
    public interface IProductService
    {
        List<Product> GetAll();

        List<Product> GetByCategory(int categoryId);

        void Add(Product product);

        void Update(Product product);

        void Delete(int productId);

        Product GetById(int productId);


    }
}
