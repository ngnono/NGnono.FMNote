using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class UserEntity : NGnono.Framework.Models.BaseEntity
    {
        public UserEntity()
        {
            this.Bills = new List<BillEntity>();
            this.Comments = new List<CommentEntity>();
            this.UserAccounts = new List<UserAccountEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public string Mobile { get; set; }
        public string EMail { get; set; }
        public int Status { get; set; }
        public int UserLevel { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public byte Gender { get; set; }
        public virtual ICollection<BillEntity> Bills { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }
        public virtual ICollection<UserAccountEntity> UserAccounts { get; set; }

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
