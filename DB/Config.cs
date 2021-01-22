using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DB
{
    public static class Config
    {
        /// <summary>
        /// 系统基础数据库
        /// </summary>
        public static SqlConnection Conn_Wathet
        {
            get { return new SqlConnection() { ConnectionString = Common.DoEncrypt.Decrypt(Common.ConfigurationManager.AppSettings["DBConnStr:SQLConnection:Wathet"]) ?? "" }; }
        }
    }
}
