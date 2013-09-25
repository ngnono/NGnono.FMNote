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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSite4App.Core.Controllers
{
    [LoginAuthorize]
    public class TagController : UserController
    {
        #region methods

        private PagerInfo<TagEntity> GetList(PagerRequest pagerRequest, TagFilterOptions filterOptions, TagSortOptions sortOptions)
        {
            var paged = PagedListGetter(pagerRequest, filterOptions, sortOptions,
                                        (IFMNoteEFUnitOfWork unitOfWork,
                                         Expression<Func<TagEntity, bool>> filter,
                                         Func<IQueryable<TagEntity>, IOrderedQueryable<TagEntity>> @orderby, PagerRequest pRequest,
                                         out int totalCount) => unitOfWork.TagRepository
                                                                          .Get(filter,
                                                                               out totalCount,
                                                                               pagerRequest
                                                                                   .PageIndex,
                                                                               pagerRequest
                                                                                   .PageSize,
                                                                               @orderby), Filler, OrderBy);

            return paged;

        }

        private static Expression<Func<TagEntity, bool>> Filler(TagFilterOptions filterOptions)
        {
            var filter = PredicateBuilder.True<TagEntity>();

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

        private static Func<IQueryable<TagEntity>, IOrderedQueryable<TagEntity>> OrderBy(TagSortOptions sortOptions)
        {
            Func<IQueryable<TagEntity>, IOrderedQueryable<TagEntity>> orderBy = null;

            switch (sortOptions)
            {
                default:
                    orderBy = v => v.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            return orderBy;
        }


        #endregion

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
        public ActionResult Create(FormCollection formCollection, TagCreateViewModel vo)
        {
            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();

            if (ModelState.IsValid)
            {
                var tmpEntity = Mapper.Map<TagCreateViewModel, TagEntity>(vo);
                tmpEntity.Status = (int)DataStatus.Normal;
                tmpEntity.UpdatedDate = DateTime.Now;
                tmpEntity.UpdatedUser = CurrentUser.CustomerId;
                tmpEntity.CreatedDate = DateTime.Now;
                tmpEntity.CreatedUser = CurrentUser.CustomerId;
                tmpEntity.User_Id = CurrentUser.CustomerId;


                var userEntity = ServiceInvoke(unitOfWork => unitOfWork.TagRepository.Insert(tmpEntity));

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
        public ActionResult Edit([FetchTag(KeyName = "tagid")]TagEntity model)
        {
            return View(model);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Edit(FormCollection formCollection, [FetchTag(KeyName = "tagid")]TagEntity model)
        {
            return View();
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete([FetchTag(KeyName = "tagid")]TagEntity model)
        {
            return View(model);
        }

        [HttpPost]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Delete(FormCollection formCollection, [FetchTag(KeyName = "tagid")]TagEntity model)
        {
            model.UpdatedDate = DateTime.Now;
            model.UpdatedUser = CurrentUser.CustomerId;
            model.Status = (int)DataStatus.None;

            var jsonResult = new JsonResult { ContentEncoding = Encoding.UTF8 };

            var result = new ExecuteResult<int>();


            ServiceInvoke<IFMNoteEFUnitOfWork>(v => v.TagRepository.Update(model));

            jsonResult.Data = result;

            return jsonResult;
        }

        [HttpGet]
        public ActionResult List(PagerRequest pagerRequest, TagFilterOptions filterOptions, TagSortOptions sortOptions)
        {
            var paged = GetList(pagerRequest, filterOptions, sortOptions);

            return View(paged);
        }

        [HttpGet]
        [ModelOwnerCheck(TakeParameterName = "model", CustomerPropertyName = "User_Id")]
        public ActionResult Details([FetchTag(KeyName = "tagid")]TagEntity model)
        {
            return View(model);
        }
    }
}
