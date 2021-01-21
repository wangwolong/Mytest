using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DB
{
    public static class Dapper
    {
        #region 查询
        public static List<T> Select<T>(this SqlConnection sqlConnection,string sql)
        {
            return sqlConnection.Query<T>(sql).AsList();
        }
        #endregion
        public static int Insert<T>(this SqlConnection sqlConnection, T model) where T:class
        {
            var sql = SqlInsert<T>(model);
            return sqlConnection.Execute(sql,model);
        }
        private static string SqlInsert<T>(T model)
        {
            var field = new List<object>();
            PropertyInfo[] properties = model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            if (properties.Length <= 0) { return null; }
            var tableName = model.GetType().Name;
            foreach (PropertyInfo item in properties)
            {
                field.Add(item.Name);
            }
            if(field.Contains("id")) field.Remove("id");
            var co1 = string.Join(",", field);
            var co2 = "@" + string.Join(",@", field);
            var sql = $"insert into {tableName}({co1}) values({co2})";
            return sql;
        }
    }
}
