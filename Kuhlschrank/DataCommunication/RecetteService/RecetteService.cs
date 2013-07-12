using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.RecetteRepository;
using DataAccess.RecetteRepositoriesImplementation;
using DataContracts;

namespace DataCommunication.RecetteService
{
    public class RecetteService : IRecetteService
    {
        IRecetteRepository _repo = new RecetteSqlServerRepository();

        #region IRecetteService Membres

        public List<Recette> GetRecetteFromProducts(List<DataContracts.Product> products)
        {
            return _repo.GetRecetteFromProducts(products);
        }

        public Recette GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recette> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Recette entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Recette entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Recette entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
