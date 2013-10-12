using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGnono.FMNote.Datas.Models;

namespace NGnono.FMNote.WebSite4App.Core.Models.ViewModel
{
    public class CategoryInfoViewModel : BaseViewModel
    {
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [Display(Name = "主要名称")]
        [Required]
        public string Name { get; set; }

        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [Display(Name = "第二名称")]
        public string SecName { get; set; }

        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [Display(Name = "索引")]
        public string Index { get; set; }

        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        public string Description { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Type { get; set; }
        [Range(0, Int32.MaxValue)]
        public int User_Id { get; set; }
        [Range(0, Int32.MaxValue)]
        public int SortOrder { get; set; }
    }


    public class CategoryViewModel
    {
    }

    public class CategoryCreateViewModel : CategoryInfoViewModel
    {

    }

    public class CategoryEditViewModel : CategoryInfoViewModel
    {
        public int Id { get; set; }
    }
}
