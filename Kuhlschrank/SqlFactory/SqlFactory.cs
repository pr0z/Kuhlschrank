using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasterflect;
using SqlFactory.Reflection;

namespace SqlFactory
{
    public enum CommandType
    {
        Insert,
        Update,
        Delete,
        Select
    }

    public class SqlFactory
    {
        private Dictionary<Type, Table> _typeInfos;
        private System.Reflection.Assembly assembly;

        public SqlFactory(System.Reflection.Assembly assembly)
        {
            this.assembly = assembly;
            this._typeInfos = new Dictionary<Type, Table>();

            foreach (Type t in assembly.TypesWith<SqlTableAttribute>())
            {
                SqlTableAttribute attr = t.Attribute<SqlTableAttribute>();

                _typeInfos[t] = new Table();
                _typeInfos[t].Name = attr.TableName;

                foreach (PropertyInfo prop in t.PropertiesWith(Flags.AllMembers | Flags.AnyVisibility, typeof(SqlFieldAttribute)))
                {
                    SqlFieldAttribute field = prop.GetCustomAttribute<SqlFieldAttribute>();
                    _typeInfos[t].Fields.Add(new Field { IsPrimary = field.IsPrimary, SqlFieldName = field.FieldName, PropertyName = prop.Name });
                }
            }
        }

        public string BuildSqlCommand<T>(T entity, CommandType build)
        {
            if (!_typeInfos.ContainsKey(entity.GetType()))
            {
                throw new Exception("Type inconnu");
            }

            Table typeInfo = _typeInfos[entity.GetType()];

            string values = string.Empty;
            string fields = string.Empty;

            switch (build)
            {
                case CommandType.Insert:
                    values = string.Join(", ", typeInfo.Fields.Select(o => entity.GetPropertyValue(o.PropertyName) != null ? entity.GetPropertyValue(o.PropertyName).ToString() : "").ToArray());
                    fields = string.Join(", ", typeInfo.Fields.Select(o => o.SqlFieldName).ToArray());
                    return string.Format("INSERT INTO {0} ({1}) VALUES ({2});", typeInfo.Name, fields, values);
                    break;
                case CommandType.Update:
                    values = string.Join(", ", typeInfo.Fields.Select(o => string.Format("{0} = {1}, ", o.SqlFieldName, entity.GetPropertyValue(o.PropertyName))).ToArray());
                    return string.Format("UPDATE {0} SET {1};", typeInfo.Name, values);
                    break;
                case CommandType.Delete:
                    return string.Format("DELETE FROM {0} WHERE id = {1}", typeInfo.Name, entity.GetPropertyValue(typeInfo.Fields.Find(o => o.IsPrimary).PropertyName));
                    break;
                case CommandType.Select:
                    return string.Format("SELECT * FROM {0};", typeInfo.Name);
                    break;
            }
            return null;
        }
    }
}
