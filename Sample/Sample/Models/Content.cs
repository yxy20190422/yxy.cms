using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Content
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 状态1:正常0:删除
        /// </summary>
        public int? status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? edittime { get; set; }

    }
}
