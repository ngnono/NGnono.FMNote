using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Models.Enums;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSite4App.Core.Models.ViewModel;
using NGnono.FMNote.WebSupport.Binder;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.FMNote.WebSupport.Mvc.Filters;
using NGnono.Framework.Data.EF;
using NGnono.Framework.Mapping;
using NGnono.Framework.Models;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    [LoginAuthorize]
    public class CategoryController : UserController
    {
        #region methods

        private PagerInfo<CategoryEntity> GetList(PagerRequest pagerRequest, CategoryFilterOptions filterOptions, CategorySortOptions sortOptions)
        {
            var paged = PagedListGetter(pagerRequest, filterOptions, sortOptions,
                                        (IFMNoteEFUnitOfWork unitOfWork,
                                         Expression<Func<CategoryEntity, bool>> filter,
                                         Func<IQueryable<CategoryEntity>, IOrderedQueryable<CategoryEntity>> @orderby, PagerRequest pRequest,
                                         out int totalCount) => unitOfWork.CategoryRepository
                                                                          .Get(filter,
                                                                               out totalCount,
                                                                               pagerRequest
                                                                                   .PageIndex,
                                                                               pagerRequest
                                                                                   .PageSize,
                                                                               @orderby), Filler, OrderBy);

            return paged;

        }

        private static Expression<Func<CategoryEntity, bool>> Filler(CategoryFilterOptions filterOptions)
        {
            var filter = PredicateBuilder.True<CategoryEntity>();

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

        private static Func<IQueryable<CategoryEntity>, IOrderedQueryable<CategoryEntity>> OrderBy(CategorySortOptions sortOptions)
        {
            Func<IQueryable<CategoryEntity>, IOrderedQueryable<CategoryEntity>> orderBy = null;

            switch (sortOptions)
            {
                default:
                    orderBy = v => v.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            return orderBy;
        }

        #endregion

        public ActionResult Search(string k)
        {
            var data = ServiceInvoke<IFMNoteEFUnitOfWork, IEnumerable<dynamic>>(
                s => s.CategoryRepository.Get(v => v.User_Id == CurrentUser.CustomerId && v.Name.Contains(k)).Take(10).Select(v => new
                    {
                        v.Id,
                        v.Name
                    }).ToList());

            var json = new JsonResult
            {
                ContentEncoding = Encoding.UTF8,
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            return json;
        }

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
        public ActionResult Create(FormCollection formCollection, CategoryCreateViewModel vo)
        {
            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();

            if (ModelState.IsValid)
            {
                var tmpEntity = Mapper.Map<CategoryCreateViewModel, CategoryEntity>(vo);
                tmpEntity.Status = (int)DataStatus.Normal;
                tmpEntity.UpdatedDate = DateTime.Now;
                tmpEntity.UpdatedUser = CurrentUser.CustomerId;
                tmpEntity.CreatedDate = DateTime.Now;
                tmpEntity.CreatedUser = CurrentUser.CustomerId;
                tmpEntity.User_Id = CurrentUser.CustomerId;


                var userEntity = ServiceInvoke(unitOfWork => unitOfWork.CategoryRepository.Insert(tmpEntity));

                result.Data = userEntity.Id;

            }
            else
            {
                result.StatusCode = StatusCode.ClientError;
            }

            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Edit([FetchCategory(KeyName = "tagid")]CategoryEntity model)
        {
            return View(model);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Edit(FormCollection formCollection, [FetchCategory(KeyName = "tagid")]CategoryEntity model)
        {
            return View();
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete([FetchCategory(KeyName = "tagid")]CategoryEntity model)
        {
            return View(model);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete(FormCollection formCollection, [FetchCategory(KeyName = "tagid")]CategoryEntity model)
        {
            model.UpdatedDate = DateTime.Now;
            model.UpdatedUser = CurrentUser.CustomerId;
            model.Status = (int)DataStatus.None;

            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();


            ServiceInvoke<IFMNoteEFUnitOfWork>(v => v.CategoryRepository.Update(model));

            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        public ActionResult List(PagerRequest pagerRequest, CategoryFilterOptions filterOptions, CategorySortOptions sortOptions)
        {
            var paged = GetList(pagerRequest, filterOptions, sortOptions);

            return View(paged);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Details([FetchCategory(KeyName = "tagid")]CategoryEntity model)
        {
            return View(model);
        }
    }
}
