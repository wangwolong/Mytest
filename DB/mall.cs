using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// mall=商场 实体定义类
    /// </summary>
    [Table("t_xw_mall")]
    public class mall : BaseEntity
    {
        /// <summary>
        /// 商场名字
        /// </summary>
        public virtual string name { get; set; }
    }
}
