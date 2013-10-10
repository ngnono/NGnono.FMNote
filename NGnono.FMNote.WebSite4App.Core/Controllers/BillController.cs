using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Models.Enums;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSite4App.Core.Models.DTO.Bill;
using NGnono.FMNote.WebSite4App.Core.Models.ViewModel;
using NGnono.FMNote.WebSupport.Binder;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;
using NGnono.Framework.Data.EF;
using NGnono.Framework.Mapping;
using NGnono.Framework.Models;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    public class BillController : UserController
    {
        #region methods

        private BillEntity Insert(BillEntity entity)
        {
            return ServiceInvoke(unitOfWork => unitOfWork.BillRepository.Insert(entity));
        }

        /// <summary>
        /// 逻辑删
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateUserId"></param>
        /// <returns></returns>
        private bool Del(BillEntity entity, int updateUserId)
        {
            return ServiceInvoke<bool>(service =>
                {
                    entity.IsDeleted = true;
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedUser = updateUserId;

                    service.BillRepository.Update(entity);

                    return true;
                });
        }

        private BillEntity Update(BillEntity entity)
        {

            ServiceInvoke<NGnono_FMNoteContextUnitOfWork>(s => s.BillRepository.Update(entity));

            return entity;
        }

        private IEnumerable<BillEntity> GetList(PagerRequest pagerRequest, out int totalCount, BillFilterOptions filterOptions, BillSortOptions sortOptions)
        {
            var count = 0;

            var t = ServiceInvoke(v => v.BillRepository.Get(Filler(filterOptions), out count, pagerRequest.PageIndex,
                                                 pagerRequest.PageSize, OrderBy(sortOptions)));

            totalCount = count;

            return t;
        }

        private static Expression<Func<BillEntity, bool>> Filler(BillFilterOptions filterOptions)
        {
            var filter = PredicateBuilder.True<BillEntity>();

            if (filterOptions.UserId != null)
            {
                filter.And(v => v.User_Id == filterOptions.UserId);
            }

            if (filterOptions.DataStatus != null)
            {
                filter.And(v => v.Status == (int)filterOptions.DataStatus.Value);
            }

            return filter;
        }

        private static Func<IQueryable<BillEntity>, IOrderedQueryable<BillEntity>> OrderBy(BillSortOptions sortOptions)
        {
            Func<IQueryable<BillEntity>, IOrderedQueryable<BillEntity>> orderBy = null;

            switch (sortOptions)
            {
                default:
                    orderBy = v => v.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            return orderBy;
        }

        #endregion


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
        public ActionResult Create(FormCollection formCollection, BillViewModel vo)
        {
            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();

            if (ModelState.IsValid)
            {
                var billEntity = Mapper.Map<BillViewModel, BillEntity>(vo);
                billEntity.CreatedDate = DateTime.Now;
                billEntity.CreatedUser = CurrentUser.CustomerId;
                billEntity.UpdatedDate = DateTime.Now;
                billEntity.UpdatedUser = CurrentUser.CustomerId;
                billEntity.Status = (int)DataStatus.Normal;

                var entity = Insert(billEntity);

                result.Data = entity.Id;
            }
            else
            {
                result.StatusCode = StatusCode.ClientError;
            }

            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        [LoginAuthorize]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete([FetchBill(KeyName = "billid")] BillEntity model)
        {
            return View(model);
        }

        [LoginAuthorize]
        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete(FormCollection formCollection, [FetchBill(KeyName = "billid")]BillEntity model)
        {
            Del(model, CurrentUser.CustomerId);

            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();

            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        [LoginAuthorize]
        public ActionResult List(PagerRequest pagerRequest, BillFilterOptions filterOptions, BillSortOptions? sortOptions)
        {
            int totalCount;

            var queryTable = GetList(pagerRequest, out totalCount, filterOptions, sortOptions ?? BillSortOptions.Default);

            var dto = new ListDTO { Bills = new PagerInfo<BillEntity>(pagerRequest, totalCount, queryTable) };

            return View(dto);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        [LoginAuthorize]
        public ActionResult Details([FetchBill(KeyName = "billid")]BillEntity model)
        {
            //var vo = Mapper.Map<BillEntity, BillViewModel>(model);

            return View(model);
        }

        [LoginAuthorize]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        [HttpGet]
        public ActionResult Edit([FetchBill(KeyName = "billid")]BillEntity model)
        {
            return View(model);
        }

        [LoginAuthorize]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        [HttpPost]
        public ActionResult Edit(FormCollection formCollection, [FetchBill(KeyName = "billid")]BillEntity model, BillViewModel vo)
        {
            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();

            if (ModelState.IsValid)
            {
                var tmp = Mapper.Map<BillViewModel, BillEntity>(vo);
                tmp.UpdatedDate = DateTime.Now;
                tmp.UpdatedUser = CurrentUser.CustomerId;
                tmp.Status = model.Status;
                tmp.CreatedDate = model.CreatedDate;
                tmp.CreatedUser = model.CreatedUser;
                tmp.Status = model.Status;
                tmp.IsDeleted = model.IsDeleted;

                Mapper.Map(tmp, model);

                Update(model);
            }
            else
            {
                result.StatusCode = StatusCode.ClientError;
                result.Message = "参数验证错误";
            }

            jsonResult.Data = result;

            return jsonResult;
        }
    }
}
