using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.WebSite4App.Core.Models.VO;
using NGnono.Framework.Models;

namespace NGnono.FMNote.WebSite4App.Core.Models.DTO.Bill
{
    public class DetailDTO : BaseDTO
    {
        public BillVO Bill { get; set; }
    }

    public class ListDTO : BaseDTO
    {
        public PagerInfo<BillEntity> Bills { get; set; }
    }
}
