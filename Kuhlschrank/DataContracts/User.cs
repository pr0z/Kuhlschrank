using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DataContracts;
using SqlFactory.Reflection;

namespace DataContracts
{
    [DataContract]
    [SqlTable("USER")]
    public class User : Entity
    {
        [DataMember]
        [SqlField("nom")]
        public string Nom { get; set; }
        [DataMember]
        [SqlField("prenom")]
        public string Prenom { get; set; }
        [DataMember]
        [SqlField("mail")]
        public string Mail { get; set; }
        [DataMember]
        [SqlField("pass")]
        public string Password { get; set; }
    }
}