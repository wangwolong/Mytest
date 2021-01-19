using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Common
{
    public class ComEnum
    {
        #region //状态码
        /// <summary>
        /// 项目状态码
        /// </summary>
        public enum Code
        {
            [Description("程序异常")]
            E_程序异常 = 500,

            #region 普通操作
            //--------------------------------------------
            //------------------用户普通操作返回--------------------
            //--------------------------------------------
            [Description("操作成功")]
            A_操作成功 = 0,
            [Description("操作失败")]
            A_操作失败 = 1,
            [Description("参数异常")]
            A_参数异常 = 2,
            [Description("未找到对象")]
            A_未找到对象 = 3,
            [Description("必填字段为空")]
            A_必填字段为空 = 4,
            [Description("输入Json与模型要求不一致")]
            A_输入Json与模型要求不一致 = 5,
            [Description("已有同名数据,请避免数据重复")]
            A_已有同名参数 = 6,
            [Description("条件判断未通过，刷新重试")]
            A_条件判断未通过 = 7,
            [Description("当前对象为失效或者禁用状态")]
            A_当前对象失效 = 8,
            [Description("数据异常")]
            A_数据错误_跳转 = 9,
            [Description("Email格式不正确")]
            A_Email格式不正确 = 10,
            [Description("需要删除理由")]
            A_需要删除理由 = 11,
            [Description("请先分配权限")]
            A_分配权限 = 12,
            [Description("邮箱已存在")]
            A_邮箱已存在 = 13,
            [Description("YAPI登录名已存在")]
            A_YAPI登录名已存在 = 14,
            #endregion
        }
        #endregion
    }
}
