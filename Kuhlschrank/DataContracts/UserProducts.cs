using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class UserProducts : Entity
    {
        [DataMember]
        public int IdProduct { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
