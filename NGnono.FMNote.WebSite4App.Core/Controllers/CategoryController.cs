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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    [LoginAuthorize]
    public class CategoryController : UserController
    {
        #region methods

        private PagerInfo<CategoryEntity> GetList(PagerRequest pagerRequest, CategoryFilterOptions filterOptions, CategorySortOptions sortOptions)
        {
            var paged = PagedListGetter(pagerRequest, filterOptions, sortOptions,
                                        (INGnono_FMNoteContextEFUnitOfWork unitOfWork,
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
            Func<IQueryable<CategoryEntity>, IOrderedQueryable<CategoryEntity>> orderBy;

            switch (sortOptions)
            {
                default:
                    orderBy = v => v.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            return orderBy;
        }

        private string CheckCategory(CategoryEntity entity)
        {
            var msg = ServiceInvoke(
                u =>
                {
                    var c1 = u.CategoryRepository.Get(
                        v =>
                        v.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase) &&
                        v.User_Id == entity.User_Id && v.Id != entity.Id).Any();
                    if (c1)
                    {
                        return "分类名称重了，请换个先";
                    }

                    return null;
                });

            AppendErrorSummary(msg);

            return msg;
        }

        #endregion

        public ActionResult Search(string k)
        {
            var data = ServiceInvoke<NGnono_FMNoteContextUnitOfWork, IEnumerable<dynamic>>(
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
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection, CategoryCreateViewModel vo, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var tmpEntity = Mapper.Map<CategoryCreateViewModel, CategoryEntity>(vo);
                tmpEntity.Status = (int)DataStatus.Normal;
                tmpEntity.UpdatedDate = DateTime.Now;
                tmpEntity.UpdatedUser = CurrentUser.CustomerId;
                tmpEntity.CreatedDate = DateTime.Now;
                tmpEntity.CreatedUser = CurrentUser.CustomerId;
                tmpEntity.User_Id = CurrentUser.CustomerId;

                var msg = CheckCategory(tmpEntity);
                if (String.IsNullOrEmpty(msg))
                {
                    var entity = ServiceInvoke(unitOfWork => unitOfWork.CategoryRepository.Insert(tmpEntity));

                    if (!Url.IsLocalUrl(returnUrl))
                    {
                        returnUrl = Url.Action("Index");
                    }

                    return Success(new SuccessViewModel
                    {
                        Msg = String.Format("分类:{0} 添加成功。", entity.Name),
                        RedirectUrl = returnUrl,
                        RedirectText = "返回"
                    });
                }
            }

            return View(vo);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Edit([FetchCategory(KeyName = "id")]CategoryEntity model)
        {
            var vo = Mapper.Map<CategoryEntity, CategoryEditViewModel>(model);

            return View(vo);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Edit(FormCollection formCollection, [FetchCategory(KeyName = "id")]CategoryEntity model, CategoryEditViewModel editViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var tmpEntity = Mapper.Map<CategoryEditViewModel, CategoryEntity>(editViewModel);
                tmpEntity.Status = model.Status;
                tmpEntity.UpdatedDate = DateTime.Now;
                tmpEntity.UpdatedUser = CurrentUser.CustomerId;
                tmpEntity.CreatedDate = model.CreatedDate;
                tmpEntity.CreatedUser = model.CreatedUser;
                tmpEntity.User_Id = model.User_Id;

                var msg = CheckCategory(tmpEntity);

                if (String.IsNullOrEmpty(msg))
                {
                    ServiceInvoke(u => u.CategoryRepository.Update(tmpEntity));

                    return Success(new SuccessViewModel
                    {
                        Msg = String.Format("分类:{0} 编辑成功。", tmpEntity.Name),
                        RedirectUrl = returnUrl,
                        RedirectText = "返回"
                    });
                }
            }

            return View(editViewModel);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete([FetchCategory(KeyName = "id")]CategoryEntity model)
        {
            return View(model);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete(FormCollection formCollection, [FetchCategory(KeyName = "id")]CategoryEntity model, string returnUrl)
        {
            model.UpdatedDate = DateTime.Now;
            model.UpdatedUser = CurrentUser.CustomerId;
            model.Status = (int)DataStatus.None;

            var n = model.Name;
            ServiceInvoke<NGnono_FMNoteContextUnitOfWork>(v => v.CategoryRepository.Update(model));

            return Success(new SuccessViewModel
            {
                Msg = String.Format("分类:{0} 编辑成功。", n),
                RedirectUrl = returnUrl,
                RedirectText = "返回"
            });
        }

        [HttpGet]
        public ActionResult List(PagerRequest pagerRequest, CategoryFilterOptions filter, CategorySortOptions? sort)
        {
            var paged = GetList(pagerRequest, filter, sort ?? CategorySortOptions.Default);

            return View("List", paged);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Details([FetchCategory(KeyName = "id")]CategoryEntity model)
        {
            return View(model);
        }
    }
}
