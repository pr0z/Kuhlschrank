using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.ProductRepositoriesImplementation;
using System.Collections.Generic;
using DataContracts;
using DataAccess.CategoryRepositoriesImplementation;
using Common.Repositories.ProductRepository;
using Common.Repositories.CategoryRepository;

namespace UnitTests
{
    [TestClass]
    public class KuhlschrankTest
    {
        [TestMethod]
        public void ShouldReturnProductList()
        {
            List<Product> result = null;
            ProductListRepository repo = new ProductListRepository();
            result = repo.GetAll();

            Assert.IsTrue(result != null && result.Count > 0);
        }
        
        [TestMethod]
        public void ShouldReturnProduct()
        {
            Product result = null;
            IProductRepository repo = new ProductListRepository();
            result = repo.GetById(1);

            Assert.IsTrue(result != null && result is Product);
        }
     
        [TestMethod]
        public void ShouldReturnProductWithEan()
        {
            Product result = null;
            ProductListRepository repo = new ProductListRepository();
            result = repo.GetByEan13("");

            Assert.IsTrue(result == null);
        }

        [TestMethod]
        public void ShouldReturnCategory()
        {
            Category result = null;
            ICategoryRepository repo = new CategoryListRepository();
            result = repo.GetById(0);

            Assert.IsTrue(result != null && result is Category);
        }

    }
}
