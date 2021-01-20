using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// detail=报名详情 实体定义类
    /// </summary>
    [Table("t_xw_detail")]
    public class detail : BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public virtual int user_id { get; set; }
        /// <summary>
        /// 场次id
        /// </summary>
        public virtual int activity_son_id { get; set; }
    }
}
