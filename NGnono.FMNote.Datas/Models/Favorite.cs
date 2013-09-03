using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class FavoriteEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int FavoriteSourceId { get; set; }
        public int FavoriteSourceType { get; set; }
        public int User_Id { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Store_Id { get; set; }

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
