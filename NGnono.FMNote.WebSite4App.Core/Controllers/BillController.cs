using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.FMNote.WebSupport.Mvc.Controllers;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    public class BillController : UserController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(FormCollection formCollection)
        {
            return View();
        }
    }
}
