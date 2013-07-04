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
        public int Id { get; set; }

        [DataMember]
        public string Libelle { get; set; }
    }
}
