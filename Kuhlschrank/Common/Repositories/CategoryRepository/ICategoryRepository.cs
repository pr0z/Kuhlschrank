using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.CategoryRepository
{
    /// <summary>
    /// Contrat du Repository Cateogry
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
