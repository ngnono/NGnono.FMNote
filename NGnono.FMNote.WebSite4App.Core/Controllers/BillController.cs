using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.WebSupport.Binder;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    public class BillController : UserController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [LoginAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [LoginAuthorize]
        public ActionResult Create(FormCollection formCollection)
        {
            return View();
        }

        [HttpGet]
        [LoginAuthorize]
        public ActionResult Delete([FetchBill(KeyName = "billid")] BillEntity model)
        {
            return View();
        }

        [LoginAuthorize]
        [HttpPost]
        public ActionResult Delete(FormCollection formCollection, [FetchBill(KeyName = "billid")]BillEntity model)
        {
            return View();
        }

        [HttpGet]
        [LoginAuthorize]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        [LoginAuthorize]
        public ActionResult Details()
        {
            return View();
        }

        [LoginAuthorize]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        [HttpGet]
        public ActionResult Edit([FetchBill(KeyName = "billid")]BillEntity model)
        {
            return View();
        }

        [LoginAuthorize]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, [FetchBill(KeyName = "billid")]BillEntity model)
        {
            return View();
        }
    }
}
