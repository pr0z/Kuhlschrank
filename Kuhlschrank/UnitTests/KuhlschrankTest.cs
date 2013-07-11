using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess.ProductRepositoriesImplementation;
using System.Collections.Generic;
using DataContracts;

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
            ProductListRepository repo = new ProductListRepository();
            result = repo.GetById(1);

            Assert.IsTrue(result != null && result is Product);
        }
    }
}
