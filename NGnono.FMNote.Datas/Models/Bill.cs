using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class BillEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Mode { get; set; }
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public System.DateTime DataDateTime { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int UpdatedUser { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public int ExtendedContentType { get; set; }
        public string ExtendedContent { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual UserEntity User { get; set; }

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
