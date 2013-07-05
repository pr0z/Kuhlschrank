using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Product : Entity
    {
        [DataMember]
        public string Libelle { get; set; }

        [DataMember]
        public int IdCategory { get; set; }
    }
}
