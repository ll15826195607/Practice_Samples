using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDemo
{
    public class Order
    {
        /// <summary>
        /// 标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public String Company { get; set; }

        /// <summary>
        /// 生成时间
        /// </summary>
        public String OrderTime { get; set; }
        /// <summary>
        /// 派单详情
        /// </summary>
        public List<String> OrderDetails { get; set; }
    }
}
