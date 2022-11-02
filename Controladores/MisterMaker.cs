using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplication7.Controladores
{
    public class MisterMaker
    {
        public static string ReadDocument(string filename)
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            string filePath = Path.Combine(assemblyPath.Replace("\\bin", "").Replace("\\Debug", "").Replace("file:\\", "").Replace("\\net5.0", "") + $"\\Controladores\\" + $"\\Queries\\", filename + ".sql");

            if (!File.Exists(filePath)) return "";

            return File.ReadAllText(filePath);
        }
        public List<T> TableToList<T>(DataTable table)
        {
            List<T> res = new List<T>();
            foreach (DataRow rw in table.Rows)
            {
                T item = Activator.CreateInstance<T>();
                foreach (DataColumn cl in table.Columns)
                {
                    PropertyInfo pi = typeof(T).GetProperty(cl.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (pi != null && rw[cl] != DBNull.Value)
                        pi.SetValue(item, ChangeType(rw[cl], pi.PropertyType), new object[0]);
                }
                res.Add(item);
            }
            return res;
        }

        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}