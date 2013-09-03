using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class GroupEntity : NGnono.Framework.Models.BaseEntity
    {
        public GroupEntity()
        {
            this.Stores = new List<StoreEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public int Status { get; set; }
        public virtual ICollection<StoreEntity> Stores { get; set; }

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
