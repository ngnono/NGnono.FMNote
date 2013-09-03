using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class TagEntity : NGnono.Framework.Models.BaseEntity
    {
        public TagEntity()
        {
            this.Products = new List<ProductEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int User_Id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public int CreatedUser { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }

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
