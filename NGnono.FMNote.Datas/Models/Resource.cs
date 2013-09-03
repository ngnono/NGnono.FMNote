using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class ResourceEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int SourceType { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UpdatedUser { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int ContentSize { get; set; }
        public string ExtName { get; set; }

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
