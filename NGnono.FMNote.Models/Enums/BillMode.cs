using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.FMNote.Models.Enums
{
    public enum BillMode
    {
        None = 0,

        /// <summary>
        /// 花费
        /// </summary>
        Spent = 1,

        /// <summary>
        /// 赚得
        /// </summary>
        Earned = 2
    }

    public enum BillType
    {
        None = 0,
        /// <summary>
        /// 现金
        /// </summary>
        Cash = 1,

        /// <summary>
        /// 银行账户
        /// </summary>
        Bank = 2
    }

    public class BillFilterOptions
    {
        public int? UserId { get; set; }

        public DataStatus? DataStatus { get; set; }
    }

    public enum BillSortOptions
    {
        Default = 0
    }
}
