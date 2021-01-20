using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB
{
    /// <summary>
    /// activitySon=活动场次 实体定义类
    /// </summary>
    [Table("t_xw_activity_son")]
    public class activitySon:BaseEntity
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public virtual int activity_id { get; set; }
        /// <summary>
        /// 场次名字
        /// </summary>
        public virtual string name { get; set; }
        /// <summary>
        /// 场次容量
        /// </summary>
        public virtual int capacity { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime startTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime endTime { get; set; }
    }
}
