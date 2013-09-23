using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NGnono.Framework.Models;

namespace NGnono.FMNote.WebSite4App.Core.Models.VO
{
    public class BillVO : BaseVO
    {
        [Display(Name = "id")]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "金额")]
        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "模式")]
        [Required]
        public int Mode { get; set; }
        // ReSharper disable InconsistentNaming
        public int User_Id { get; set; }
        public int Category_Id { get; set; }
        // ReSharper restore InconsistentNaming

        [Display(Name = "模式")]
        [Required]
        public int Type { get; set; }

        [Display(Name = "模式")]
        public string Description { get; set; }
        public System.DateTime DataDateTime { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int CreatedUser { get; set; }
        public int UpdatedUser { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public int ExtendedContentType { get; set; }
        public string ExtendedContent { get; set; }

        public virtual CategoryVO Category { get; set; }
        public virtual UserVO User { get; set; }
        public virtual List<TagVO> Tags { get; set; }

    }




    public class CategoryVO : BaseVO
    {
    }

    public class UserVO : BaseVO
    {
    }

    public class TagVO : BaseVO
    {
    }
}
