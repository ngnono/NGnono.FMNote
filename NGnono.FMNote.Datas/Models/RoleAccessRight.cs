using System;
using System.Collections.Generic;

namespace NGnono.FMNote.Datas.Models
{
    public partial class RoleAccessRightEntity : NGnono.Framework.Models.BaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccessRightId { get; set; }
        public virtual AdminAccessRightEntity AdminAccessRight { get; set; }
        public virtual RoleEntity Role { get; set; }

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
