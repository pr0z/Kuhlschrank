using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Recette : Entity
    {
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public List<string> Ingrédients { get; set; }

        [DataMember]
        public List<string> Instructions { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
