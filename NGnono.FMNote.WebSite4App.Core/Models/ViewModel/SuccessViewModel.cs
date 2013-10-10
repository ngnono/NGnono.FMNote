using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGnono.FMNote.WebSite4App.Core.Models.ViewModel
{
    public class SuccessViewModel : BaseViewModel
    {
        public string Msg { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectText { get; set; }
    }
}
