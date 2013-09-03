using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class PriceSettingEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int SourceId { get; set; }
        public int SourceType { get; set; }
        public System.DateTime SourceDate { get; set; }
        public int Type { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Status { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public virtual ProductEntity Product { get; set; }

 #region Overrides of BaseEntity

        /// <summary>
        /// KeyMemberId
        /// </summary>
        public override object EntityId
        {       
                get { return Id; }
 
        }

        #endregion

    }
}
