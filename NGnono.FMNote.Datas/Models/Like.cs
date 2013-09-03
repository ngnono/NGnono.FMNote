using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class LikeEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int LikeUserId { get; set; }
        public int LikedUserId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }

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
