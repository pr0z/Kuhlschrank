using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Entity
    {
        public Entity() { }

        [DataMember]
        public int ID { get; set; }
    }
}
