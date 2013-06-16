using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DataContracts;

namespace DataContracts
{
    [DataContract]
    public class User : Entity
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Prenom { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}