using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// user=用户 实体定义类
    /// </summary>
    [Table("t_xw_user")]
    public class user : BaseEntity
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public virtual string name { get; set; }
        /// <summary>
        /// 性别（0未知，1男，2女）
        /// </summary>
        public virtual int sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public virtual int age { get; set; }
    }
}
