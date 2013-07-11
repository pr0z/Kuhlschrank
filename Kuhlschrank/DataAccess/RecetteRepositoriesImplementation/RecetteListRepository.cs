using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.RecetteSelector;
using Common.Repositories.RecetteRepository;
using DataContracts;

namespace DataAccess.RecetteRepositoriesImplementation
{
    public class RecetteListRepository : IRecetteRepository
    {
        private List<Recette> _source = new List<Recette>();

        #region IRecetteRepository Membres

        public List<Recette> GetRecetteFromProducts(List<Product> products)
        {
            return RecetteSelector.SelectBestRecettes(GetAll(), products);
        }

        #endregion

        #region IRepository<Recette> Membres

        public DataContracts.Recette GetById(int id)
        {
            return _source.First(o => o.ID == id);
        }

        public List<DataContracts.Recette> GetAll()
        {
            return _source;
        }

        public void Insert(DataContracts.Recette entity)
        {
            _source.Add(entity);
        }

        public void Update(DataContracts.Recette entity)
        {
            Recette rec = _source.Find(o => o.ID == entity.ID);
            if (rec != null)
            {
                rec.Ingrédients = entity.Ingrédients;
                rec.Instructions = entity.Instructions;
                rec.Nom = entity.Nom;
                rec.Description = entity.Description;
            }
        }

        public void Delete(DataContracts.Recette entity)
        {
            _source.RemoveAll(o => o.ID == entity.ID);
        }

        #endregion
    }
}
