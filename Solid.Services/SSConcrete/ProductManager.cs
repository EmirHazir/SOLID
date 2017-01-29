﻿using Solid.Services.SSAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.Entities.SSConcrete;
using Solid.Data.SDAbstract;

namespace Solid.Services.SSConcrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }



        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product {ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(x=>x.CategoryId == categoryId);
        }

        //public Product GetById(int productId)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
