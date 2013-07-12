using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.RecetteRepository;
using System.Data.SqlClient;
using System.Data;
using DataContracts;
using Common.Helpers;
using Business.RecetteSelector;

namespace DataAccess.RecetteRepositoriesImplementation
{
    public class RecetteSqlServerRepository : IRecetteRepository
    {
        #region IRecetteRepository Membres

        public List<DataContracts.Recette> GetRecetteFromProducts(List<DataContracts.Product> products)
        {
            string query = string.Format("SELECT * FROM RECIPE");
            using (SqlCommand cmd = AccessBD.Connection.CreateCommand())
            {
                cmd.CommandText = query;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    List<Recette> recettes = MapRECIPE(reader);
                    return RecetteSelector.SelectBestRecettes(recettes, products);
                }
            }
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

        private List<Recette> MapRECIPE(IDataReader reader)
        {
            List<Recette> result = new List<Recette>();

            while (reader.Read())
            {
                Recette recette = new Recette();
                recette.Ingrédients = new List<string>();
                recette.Instructions = new List<string>();

                recette.ID = Tools.ChangeType<int>(reader["id"]);
                recette.Nom = Tools.ChangeType<string>(reader["nom"]);
                recette.Description = Tools.ChangeType<string>(reader["description"]);

                string ing = Tools.ChangeType<string>(reader["ingredients"]);
                string inst = Tools.ChangeType<string>(reader["instructions"]);

                ing = ing.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
                List<string> ingredients = ing.Split('|').ToList();
                foreach (string ingredient in ingredients)
                {
                    string[] splitted = ingredient.Split(';'); 
                    recette.Ingrédients.Add(string.Format(splitted[0].Trim(), splitted[1], splitted[2]));
                }

                inst = inst.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
                List<string> instructions = inst.Split('.').ToList();
                foreach (string instruction in instructions)
                    recette.Instructions.Add(instruction.Trim());

                result.Add(recette);
            }

            return result;
        }
    }
}
