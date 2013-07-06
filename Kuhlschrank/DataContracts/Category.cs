using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Category : Entity
    {
        [DataMember]
        public string Libelle { get; set; }
    }
}
