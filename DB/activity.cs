using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// activity=活动 实体定义类
    /// </summary>
    [Table("t_xw_activity")]
    public class activity:BaseEntity
    {
        /// <summary>
        /// 活动名称
        /// </summary>
        public virtual string name { get; set; }
        /// <summary>
        /// 活动详情
        /// </summary>
        public virtual string detail { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime endTime { get; set; }
        /// <summary>
        /// 商场id
        /// </summary>
        public virtual string mall_id { get; set; }
        /// <summary>
        /// 商户id
        /// </summary>
        public virtual string merchants_id { get; set; }
    }
}
