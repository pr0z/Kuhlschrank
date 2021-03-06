﻿using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.ProductRepository
{
    /// <summary>
    /// Contrat du Repository Prodcut
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        DataContracts.Product GetByEan13(string ean13);
    }
}
