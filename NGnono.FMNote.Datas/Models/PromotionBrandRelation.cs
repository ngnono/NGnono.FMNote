using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class PromotionBrandRelationEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int Promotion_Id { get; set; }
        public int Brand_Id { get; set; }
        public System.DateTime CreatedDate { get; set; }

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
