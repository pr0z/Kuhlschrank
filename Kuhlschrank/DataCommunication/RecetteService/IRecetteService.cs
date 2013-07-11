using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories.RecetteRepository;
using DataContracts;

namespace DataCommunication.RecetteService
{
    [ServiceContract]
    public interface IRecetteService : IRecetteRepository
    {
        #region IRecetteRepository Membres

        [OperationContract]
        new List<Recette> GetRecetteFromProducts(List<Product> products);

        #endregion

        #region IRepository<Recette> Membres

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new Recette GetById(int id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        new List<Recette> GetAll();

        [OperationContract]
        new void Insert(Recette entity);

        [OperationContract]
        new void Update(Recette entity);

        [OperationContract]
        new void Delete(Recette entity);

        #endregion
    }
}
