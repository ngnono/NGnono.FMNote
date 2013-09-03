using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class BillTagRelationEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int Bill_Id { get; set; }
        public int Tag_Id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }

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
