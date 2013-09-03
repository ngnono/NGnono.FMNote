using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class ProductUploadJobEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> InUser { get; set; }
        public string FileName { get; set; }
        public Nullable<int> Status { get; set; }

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
