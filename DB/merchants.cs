using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// merchants=商户 实体定义类
    /// </summary>
    [Table("t_xw_merchants")]
    public class merchants : BaseEntity
    {
        /// <summary>
        /// 商户名字
        /// </summary>
        public virtual string name { get; set; }
        /// <summary>
        /// 商场id
        /// </summary>
        public virtual int xw_mall_id { get; set; }
    }
}
