using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ArtiLib.Data.DaoUtils
{
    public static class QueryHelper
    {
        public static string[] GetPropertyNames(this Type type) =>
            type
                .GetProperties()
                .Select(prop => prop.Name)
                .ToArray();

        public static string EncodeForLike(this string Value)
        {
            return Value.Replace("%", "[%]").Replace("[", "[[]").Replace("]", "[]]").Replace("_", "[_]").Replace("'", "''");
        }

        private static TableAttribute GetTable(this Type type)
        {
            TableAttribute tableName = (Attribute.GetCustomAttribute(type, typeof(TableAttribute)) is TableAttribute) ?
                                       (Attribute.GetCustomAttribute(type, typeof(TableAttribute)) as TableAttribute) : null;
            if (tableName == null)
            {
                throw new DataException("Référence table manquante.");
            }
            else
            {
                return tableName;
            }
        }

        private static ColumnAttribute GetColumn(this PropertyInfo propertyInfo)
        {
            return (propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false) is ColumnAttribute[]) ?
                   (ColumnAttribute)propertyInfo.GetCustomAttributes(typeof(ColumnAttribute), false).Single() : null;
        }

        private static IEnumerable<PropertyInfo> GetColumns(this PropertyInfo[] propertyInfo)
        {
            var columnsPropertyInfo = propertyInfo.Where(x => Attribute.IsDefined(x, typeof(ColumnAttribute)));
            if (columnsPropertyInfo == null || columnsPropertyInfo.Count() == 0)
            {
                throw new DataException("Référence colonne manquante.");
            }
            else
            {
                return columnsPropertyInfo;
            }
        }

        private static PropertyInfo GetPrimaryKey(this IEnumerable<PropertyInfo> propertiesInfo)
        {
            var primaryKeyPropertyInfo = propertiesInfo.Single(x => Attribute.IsDefined(x, typeof(KeyAttribute)));
            if (primaryKeyPropertyInfo == null)
            {
                throw new DataException("Référence clé primaire manquante.");
            }
            else
            {
                return primaryKeyPropertyInfo;
            }
        }

        private static ForeignKeyAttribute GetForeignKey(this PropertyInfo propertyInfo)
        {
            return (propertyInfo.GetCustomAttributes(typeof(ForeignKeyAttribute), false) is ForeignKeyAttribute[]) ?
                   (ForeignKeyAttribute)propertyInfo.GetCustomAttributes(typeof(ForeignKeyAttribute), false).Single() : null;
        }

        public static string InsertQuery(this Type type, bool blnKeyId = false)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var primaryKeyPropertyInfo = type.GetProperties().GetColumns().GetPrimaryKey();
            string query = $"INSERT INTO {type.GetTable().Name} ( ";
            var columnsPropertyInfos = type.GetProperties().GetColumns();
            foreach (var property in columnsPropertyInfos)
            {
                if (!blnKeyId && property == primaryKeyPropertyInfo)
                {
                    continue;
                }
                stringBuilder.Append(property.GetColumn().Name + ", ");
            }
            string columns = stringBuilder.ToString(0, stringBuilder.ToString().Length - 2);
            string values = "@" + columns.Replace(", ", ", @");
            query = stringBuilder.Clear()
                                 .Append(query)
                                 .Append(columns)
                                 .Append(" ) VALUES( ")
                                 .Append(values)
                                 .Append(" ); SELECT CAST(SCOPE_IdENTITY() as int)").ToString();
            query = null;
            columns = null;
            values = null;
            stringBuilder = null;
            return query;
        }

        public static string UpdateQuery(this Type type, bool blnKeyId = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"UPDATE {type.GetTable().Name} SET ");
            foreach (var property in type.GetProperties())
            {
                if (Attribute.IsDefined(property, typeof(ColumnAttribute)))
                {
                    var columnAttribute = property.GetColumn();
                    stringBuilder.Append(columnAttribute.Name + " = @" + columnAttribute.Name + ", ");
                }
            }
            string stringBuilderValue = stringBuilder.ToString(0, (stringBuilder.ToString().Length - 2));
            if (blnKeyId)
            {
                stringBuilderValue += " Where Id = @Id";
            }
            stringBuilder = null;
            return stringBuilderValue;
        }

        public static string DeleteAllQuery(this Type type)
        {
            return $"DELETE FROM {type.GetTable().Name}";
        }

        public static string DeleteByIdQuery(this Type type)
        {
            return $"DELETE FROM {type.GetTable().Name} WHERE Id = @Id";
        }

        public static string DeleteByCriteriaQuery(this Type type, object criteria)
        {
            return $"DELETE FROM {type.GetTable().Name} WHERE {criteria} = @{criteria}";
        }

        public static string DeleteByGetByWhereExpressionQuery(this Type type, string whereExpression)
        {
            return $"DELETE FROM {type.GetTable().Name} WHERE {whereExpression}";
        }

        public static string GetAllQuery(this Type type)
        {
            return $"SELECT * FROM {type.GetTable().Name}";
        }

        private static string GenerateForeignKeyMappingQuery(this TableAttribute tableAttribute, IEnumerable<PropertyInfo> foreignKeyAttributes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"SELECT * FROM {tableAttribute.Name} ");
            string foreignKeyId = string.Empty;
            string foreignTableName = string.Empty;
            string foreignTablePrimaryKey = string.Empty;
            foreach (var item in foreignKeyAttributes)
            {
                foreignKeyId = item.GetForeignKey().Name;
                foreignTableName = item.PropertyType.GetTable().Name;
                foreignTablePrimaryKey = item.PropertyType.GetProperties().GetColumns().GetPrimaryKey().Name;
                if (foreignTableName.Equals(tableAttribute.Name))
                {
                    stringBuilder.Append($"INNER JOIN {foreignTableName + " " + foreignTableName.Substring(0, 3)} ON {tableAttribute.Name}.{foreignKeyId} = {foreignTableName.Substring(0, 3)}.{foreignTablePrimaryKey} ");
                }
                else
                {
                    stringBuilder.Append($"INNER JOIN {foreignTableName} ON {tableAttribute.Name}.{foreignKeyId} = {foreignTableName}.{foreignTablePrimaryKey} ");
                }
            }
            string query = stringBuilder.ToString();
            foreignKeyId = null;
            foreignTableName = null;
            foreignTablePrimaryKey = null;
            stringBuilder = null;
            return query;
        }

        public static string GetAllMappingQuery(this Type type)
        {
            var foreignKeyAttributes = type.GetProperties().Where(x => Attribute.IsDefined(x, typeof(ForeignKeyAttribute)));
            var tableAttribute = type.GetTable();
            if (foreignKeyAttributes == null)
            {
                return $"SELECT * FROM {tableAttribute.Name}";
            }
            return tableAttribute.GenerateForeignKeyMappingQuery(foreignKeyAttributes);
        }

        public static string GetByIdQuery(this Type type)
        {
            return $"SELECT * FROM {type.GetTable().Name} WHERE Id = @Id";
        }

        public static string GetByCriteriaQuery(this Type type, object criteria)
        {
            return $"SELECT * FROM {type.GetTable().Name} WHERE {criteria} = @{criteria}";
        }

        public static string GetByGetByWhereExpressionQuery(this Type type, string whereExpression)
        {
            return $"SELECT * FROM {type.GetTable().Name} WHERE {whereExpression}";
        }
    }

    [Serializable]
    public class DataException : Exception
    {
        public DataException()
        {
        }

        public DataException(string message) : base(message)
        {
        }

        public DataException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}