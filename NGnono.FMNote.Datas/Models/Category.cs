using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class CategoryEntity : NGnono.Framework.Models.BaseEntity
    {
        public CategoryEntity()
        {
            this.Bills = new List<BillEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public string Index { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int User_Id { get; set; }
        public int Status { get; set; }
        public int SortOrder { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public virtual ICollection<BillEntity> Bills { get; set; }

        public int ParentId { get; set; }

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
