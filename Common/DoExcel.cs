using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Common
{
    public class DoExcel
    {
        #region 使用List<T>写入Excel
        /// <summary>
        /// 使用List<T>写入Excel
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">导出集合</param>
        /// <param name="IsAppendTitle">是否需要标题</param>
        /// <param name="Headers">标题</param>
        /// <returns></returns>
        public static byte[] CreateReturnBytes<T>(List<T> list, bool IsAppendTitle = true, string[] Headers = null)
        {
            return CreateReturnBytes(list.ToDataTable<T>(), IsAppendTitle, Headers);
        }
        #endregion

        #region 从DataTable生成Excel
        /// <summary>
        /// 从DataTable生成Excel
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="IsAppendTitle">是否添加标题</param>
        /// <param name="Headers">标题</param>
        /// <returns></returns>
        public static byte[] CreateReturnBytes(DataTable dt, bool IsAppendTitle = true, string[] Headers = null)
        {
            try
            {

                dt = dt ?? new DataTable();
                //创建Excel文件的对象
                HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                //添加一个sheet
                ISheet sheet1 = book.CreateSheet("Sheet1");

                #region //书写标题
                if (IsAppendTitle)
                {
                    if (Headers == null || Headers.Length == 0) { Headers = dt.GetColumnNames().ToArray(); }

                    //给sheet1添加第一行的头部标题
                    IRow row1 = sheet1.CreateRow(0);

                    for (int i = 0; i < Headers.Length; i++)
                    {
                        row1.CreateCell(i).SetCellValue(Headers[i]);
                    }
                }
                #endregion

                #region //填充数据
                var k = IsAppendTitle ? 1 : 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //创建数据行
                    IRow rowtemp = sheet1.CreateRow(k);
                    rowtemp.CreateCell(0).SetCellValue((k).ToString());
                    k++;
                    //填充数据
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        var value = dt.Rows[i][j].ToString();
                        rowtemp.CreateCell(j).SetCellValue(value);
                    }
                }
                #endregion
                #region //写入文件
                using (MemoryStream ms = new MemoryStream())
                {
                    book.Write(ms);

                    var t = ms.ToArray();
                    return t;
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new byte[0];
            }
        }
        #endregion
    }
}
