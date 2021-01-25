using Common;
using DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.WebEntity;

namespace StatisticalAnalysis.Controllers.StatisticalAnalysis
{
    public class ActivityController : BaseController
    {
        [HttpGet]
        public JsonR Index()
        {
            return Common.ComEnum.Code.A_操作成功.JsonR();
        }
        [HttpPost]
        public JsonR Select(string tableName ,string where)
        {
            if (where == null) where = "1=1";
            var sql = $"select * from {tableName } where {where}";
            return Common.ComEnum.Code.A_操作成功.JsonR(DB.Config.Conn_Wathet.Select<DB.activity>(sql));
        }
        [HttpGet]
        public JsonR DoEncrypt(string encrypt)
        {
            return Common.ComEnum.Code.A_操作成功.JsonR(Common.DoEncrypt.Encrypt(encrypt));
        }
        [HttpGet]
        public JsonR DoDecrypt(string Decrypt)
        {
            return Common.ComEnum.Code.A_操作成功.JsonR(Common.DoEncrypt.Decrypt(Decrypt));
        }
    }
}
