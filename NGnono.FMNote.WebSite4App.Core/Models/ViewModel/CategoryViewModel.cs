using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGnono.FMNote.Datas.Models;

namespace NGnono.FMNote.WebSite4App.Core.Models.ViewModel
{
    public class CategoryInfoViewModel : BaseViewModel
    {
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
    }


    public class CategoryViewModel
    {
    }

    public class CategoryCreateViewModel : CategoryInfoViewModel
    {

    }
}
