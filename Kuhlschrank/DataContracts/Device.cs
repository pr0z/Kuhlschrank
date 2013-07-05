using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContracts
{
    [DataContract]
    public class Device : Entity
    {
        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string uniqueIdentifier { get; set; }

        [DataMember]
        public int userId { get; set; }
    }
}
