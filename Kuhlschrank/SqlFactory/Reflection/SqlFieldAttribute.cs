using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFactory.Reflection
{
    public class SqlFieldAttribute : Attribute
    {
        public string FieldName { get; set; }
        public bool IsPrimary { get; set; }

        public SqlFieldAttribute(string fieldName, bool isPrimary = false)
        {
            this.FieldName = fieldName;
            this.IsPrimary = isPrimary;
        }
    }
}
