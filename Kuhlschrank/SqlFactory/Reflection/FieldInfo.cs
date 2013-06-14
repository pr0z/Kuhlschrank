using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFactory.Reflection
{
    public struct Field
    {
        public bool IsPrimary { get; set; }
        public string SqlFieldName { get; set; }
        public string PropertyName { get; set; }
    }
}
