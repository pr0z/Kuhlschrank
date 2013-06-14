using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlFactory.Reflection
{
    public class Table
    {
        public Table()
        {
            Fields = new List<Field>();
        }

        public string Name { get; set; }
        public List<Field> Fields { get; private set; }
    }
}
