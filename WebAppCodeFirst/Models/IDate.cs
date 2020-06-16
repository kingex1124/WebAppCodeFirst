using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCodeFirst.Models
{
    public interface IDate
    {
        /// <summary>
        /// 建立日期
        /// </summary>
        DateTime CreateDate { get; set; }
        /// <summary>
        /// 建立人
        /// </summary>
        string CreateUser { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        DateTime UpdateDate { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        string UpdateUser { get; set; }
    }
}
