using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class FeedbackEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Contact { get; set; }
        public int User_Id { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedUser { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UpdatedUser { get; set; }

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
