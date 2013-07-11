using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.RecetteRepository;
using DataAccess.WebServices;

namespace DataAccess.RecetteRepositoriesImplementation
{
    public class RecetteServiceRepository : IRecetteRepository
    {
        #region IRecetteRepository Membres

        public List<DataContracts.Recette> GetRecetteFromProducts(List<DataContracts.Product> products)
        {
            return MyWebServices.RecetteService.GetRecetteFromProducts(products);
        }

        #endregion

        #region IRepository<Recette> Membres

        public DataContracts.Recette GetById(int id)
        {
            return MyWebServices.RecetteService.GetById(id);
        }

        public List<DataContracts.Recette> GetAll()
        {
            return MyWebServices.RecetteService.GetAll();
        }

        public void Insert(DataContracts.Recette entity)
        {
            MyWebServices.RecetteService.Insert(entity);
        }

        public void Update(DataContracts.Recette entity)
        {
            MyWebServices.RecetteService.Update(entity);
        }

        public void Delete(DataContracts.Recette entity)
        {
            MyWebServices.RecetteService.Delete(entity);
        }

        #endregion
    }
}
