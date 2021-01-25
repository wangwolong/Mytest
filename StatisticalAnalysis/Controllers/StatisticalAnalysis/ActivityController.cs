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
        /// <summary>
        /// 调试swagger
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonR Index()
        {
            return Common.ComEnum.Code.A_操作成功.JsonR();
        }
        /// <summary>
        /// 进行简单的查询
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonR Select(string tableName ,string where)
        {
            if (where == null) where = "1=1";
            var sql = $"select * from {tableName } where {where}";
            return Common.ComEnum.Code.A_操作成功.JsonR(DB.Config.Conn_Wathet.Select<DB.activity>(sql));
        }
        /// <summary>
        /// 尝试加密
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonR DoEncrypt(string encrypt)
        {
            return Common.ComEnum.Code.A_操作成功.JsonR(Common.DoEncrypt.Encrypt(encrypt));
        }
        /// <summary>
        /// 尝试解密
        /// </summary>
        /// <param name="Decrypt"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonR DoDecrypt(string Decrypt)
        {
            return Common.ComEnum.Code.A_操作成功.JsonR(Common.DoEncrypt.Decrypt(Decrypt));
        }
        /// <summary>
        /// 尝试导出 把数据存到本地文件夹
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonR Export()
        {
            var model = DB.Config.Conn_Wathet.Select<DB.activity>("select * from t_xw_activity");
            var data = DoExcel.CreateReturnBytes(model);//转化为byte数组
            System.IO.File.WriteAllBytes("Download\\Excel\\activity.xls", data);//写入本地文件夹
            return Common.ComEnum.Code.A_操作成功.JsonR("Download\\Excel\\activity.xls");
        }
        /// <summary>
        /// 导出 把数据传到页面可以进行下载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DownFile()
        {
            var model = DB.Config.Conn_Wathet.Select<DB.activity>("select * from t_xw_activity");
            var data = DoExcel.CreateReturnBytes(model);
            return File(data, "application/octet-stream", "activity.xls");
        }
        /// <summary>
        /// 导出 根据文件名称导出本地特定文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DownloadExcel(string fileName)
        {
            fileName += ".xls";
            var url = "Download\\Excel\\"+ fileName;
            var stream = new System.Net.WebClient().OpenRead(url);
            return File(stream, "application/octet-stream", fileName);
        }
    }
}
