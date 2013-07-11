using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts;

namespace Common.Repositories.RecetteRepository
{
    public interface IRecetteRepository : IRepository<Recette>
    {
        List<Recette> GetRecetteFromProducts(List<Product> products);
    }
}
