using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    [Serializable]
    public class BaseEntity
    {
        public BaseEntity()
        {
            sortNo = 10000;
            createTime = DateTime.Now;
            updateTime = DateTime.Now;
            valid = true;
            deleted = false;
            description = string.Empty;
            createrID = 0;
            createrName = string.Empty;
        }

        /// <summary>
        /// 标识列
        /// </summary>
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string description { get; set; }
        /// <summary>
        /// 排序数字
        /// </summary>
		public virtual int sortNo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
		public virtual DateTime createTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
		public virtual DateTime updateTime { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
		public virtual bool valid { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
		public virtual bool deleted { get; set; }
        /// <summary>
        /// 创建者编号
        /// </summary>
        public virtual int createrID { get; set; }
        /// <summary>
        /// 创建者名称
        /// </summary>
        public virtual string createrName { get; set; }
    }
}
