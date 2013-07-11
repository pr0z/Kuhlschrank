using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.RecetteRepository;

namespace DataAccess.RecetteRepositoriesImplementation
{
    public class RecetteSqlServerRepository : IRecetteRepository
    {
        #region IRecetteRepository Membres

        public List<DataContracts.Recette> GetRecetteFromProducts(List<DataContracts.Product> products)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRepository<Recette> Membres

        public DataContracts.Recette GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataContracts.Recette> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(DataContracts.Recette entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DataContracts.Recette entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DataContracts.Recette entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
