using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class CommentEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
        public int User_Id { get; set; }
        public int SourceId { get; set; }
        public int SourceType { get; set; }
        public int ReplyUser { get; set; }
        public int ReplyId { get; set; }
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
