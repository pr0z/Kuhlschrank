using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFactory.Reflection
{
    public class SqlTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public SqlTableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
    }
}
