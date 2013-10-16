using System.Collections;
using System.Globalization;
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
using NGnono.Framework.Extension;
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

        public ActionResult GetAll(string fromat)
        {
            const string rawSql = @" WITH DATA AS (
                  SELECT [Id]
                        ,[Name]
                        ,[SecName]
                        ,[Index]
                        ,[ParentId]
                        ,[Description]
                        ,[Type]
                        ,[User_Id]
                        ,[Status]
                        ,[SortOrder]
                        ,[CreatedDate]
                        ,[CreatedUser]
                        ,[UpdatedDate]
                        ,[UpdatedUser]
                        ,CAST([Id] AS VARCHAR) AS Ids
                        ,CAST([Name] AS NVARCHAR) AS [Path]
                        ,0 AS Depth
                        ,ROW_NUMBER() OVER(ORDER BY [SortOrder] DESC) AS 
                         RowNumber
                  FROM   [dbo].[Category] AS g WITH (NOLOCK)
                  WHERE  [User_Id] = {0}
                         AND g.ParentId = 0
                  UNION ALL
                  SELECT s.[Id]
                        ,s.[Name]
                        ,s.[SecName]
                        ,s.[Index]
                        ,s.[ParentId]
                        ,s.[Description]
                        ,s.[Type]
                        ,s.[User_Id]
                        ,s.[Status]
                        ,s.[SortOrder]
                        ,s.[CreatedDate]
                        ,s.[CreatedUser]
                        ,s.[UpdatedDate]
                        ,s.[UpdatedUser]
                        ,CAST(DATA.Ids + '->' + CAST(s.[Id] AS VARCHAR) AS VARCHAR) AS 
                         Ids
                        ,CAST(DATA.[Path] + '->' + s.[Name] AS NVARCHAR) AS 
                         [Path]
                        ,DATA.[Depth] + 1 AS Depth
                        ,DATA.RowNumber
                  FROM   [dbo].[Category] AS s WITH(NOLOCK)
                         INNER JOIN DATA
                              ON  s.ParentID = DATA.Id
              )
SELECT *
FROM   DATA
ORDER BY
       RowNumber
      ,Depth
      ,[SortOrder] DESC;";

            var datas = ServiceInvoke(u => u.DbContext.Database.SqlQuery<CategoryStructViewModel>(rawSql, CurrentUser.CustomerId).ToList());

            var list = new List<TreeStruct>();
            TreeStruct lastTree = null;
            TreeStruct l2 = null;
            foreach (var item in datas)
            {
                if (item.Depth == 0)
                {
                    lastTree = new TreeStruct
                        {
                            Id = item.Id.ToString(CultureInfo.InvariantCulture),
                            Name = item.Name,
                            ParentId = item.ParentId.ToString(CultureInfo.InvariantCulture)
                        };

                    list.Add(lastTree);

                    continue;
                }

                if (lastTree == null)
                {
                    continue;
                }

                if (item.Depth == 1)
                {
                    l2 = new TreeStruct
                        {
                            Id = item.Id.ToString(CultureInfo.InvariantCulture),
                            Name = item.Name,
                            ParentId = item.ParentId.ToString(CultureInfo.InvariantCulture)
                        };

                    lastTree.Childs.Add(l2);

                    continue;
                }

                if (l2 == null)
                {
                    continue;
                }

                l2.Childs.Add(new TreeStruct
                {
                    Id = item.Id.ToString(CultureInfo.InvariantCulture),
                    Name = item.Name,
                    ParentId = item.ParentId.ToString(CultureInfo.InvariantCulture)
                });

            }

            var content = new ContentResult {Content = GTree(list)};

            return content;
        }


        #region 老版本 有性能问题

        public ActionResult GetData()
        {
            //TODO:这个list集合查找 性能差，看看有没有好的性能提升方法

            const string rawSql = @"  WITH DATA AS (
                   SELECT [Id]
                         ,[Name]
                         ,[SecName]
                         ,[Index]
                         ,[ParentId]
                         ,[Description]
                         ,[Type]
                         ,[User_Id]
                         ,[Status]
                         ,[SortOrder]
                         ,[CreatedDate]
                         ,[CreatedUser]
                         ,[UpdatedDate]
                         ,[UpdatedUser]
                         ,CAST([Id] AS VARCHAR) AS Ids
                         ,CAST([Name] AS NVARCHAR) AS [Path]
                         ,0 AS Depth
                   FROM   [dbo].[Category] AS g WITH (NOLOCK)
                   WHERE  [User_Id] = {0}
                          AND g.ParentId = 0
                   UNION ALL
                   SELECT s.[Id]
                         ,s.[Name]
                         ,s.[SecName]
                         ,s.[Index]
                         ,s.[ParentId]
                         ,s.[Description]
                         ,s.[Type]
                         ,s.[User_Id]
                         ,s.[Status]
                         ,s.[SortOrder]
                         ,s.[CreatedDate]
                         ,s.[CreatedUser]
                         ,s.[UpdatedDate]
                         ,s.[UpdatedUser]
                         ,CAST(DATA.Ids + '->' + CAST(s.[Id] AS VARCHAR) AS VARCHAR) AS 
                          Ids
                         ,CAST(DATA.[Path] + '->' + s.[Name] AS NVARCHAR) AS 
                          [Path]
                         ,DATA.[Depth] + 1 AS Depth
                   FROM   [dbo].[Category] AS s WITH(NOLOCK)
                          INNER JOIN DATA
                               ON  s.ParentID = DATA.Id
               )
SELECT *
FROM   DATA
ORDER BY
       [Depth] ASC
      ,[SortOrder] DESC";

            var datas = ServiceInvoke(u => u.DbContext.Database.SqlQuery<CategoryStructViewModel>(rawSql, CurrentUser.CustomerId).ToList());

            var t = AddTree(datas, 0, 2);

            return Content(GTree(t));
        }

        internal class TreeStruct
        {
            public TreeStruct()
            {
                Childs = new List<TreeStruct>();
                ChildKeys = new HashSet<string>();
            }

            public string Id { get; set; }

            public string Name { get; set; }

            public string ParentId { get; set; }

            public bool HasChild
            {
                get
                {
                    return Childs != null && Childs.Count != 0;
                }
            }

            public List<TreeStruct> Childs { get; set; }

            public HashSet<string> ChildKeys { get; set; }

        }

        private static List<TreeStruct> AddTree(List<CategoryStructViewModel> datas, int parentId, int breakLevel)
        {
            var ds = datas.Where(v => v.ParentId == parentId);

            var list = new List<TreeStruct>();
            foreach (var item in ds)
            {
                if (item.Depth > breakLevel)
                {
                    return list;
                }

                var treeNode = new TreeStruct
                    {
                        Id = item.Id.ToString(CultureInfo.InvariantCulture),
                        Name = item.Name,
                        ParentId = item.ParentId.ToString(CultureInfo.InvariantCulture)
                    };

                var childs = AddTree(datas.Where(v => v.Depth > item.Depth).ToList(), item.Id, breakLevel);

                treeNode.Childs = childs;

                list.Add(treeNode);
            }

            return list;
        }

        private const string LiFormat = "<li data-val=\"{0}\">{1}";

        private static string GTree(IEnumerable<TreeStruct> datas)
        {

            var sb = new StringBuilder();
            foreach (var item in datas)
            {
                sb.Append(String.Format(LiFormat, item.Id, item.Name));

                if (item.HasChild)
                {
                    sb.Append("<ul>");

                    sb.Append(GTree(item.Childs));

                    sb.Append("</ul>");
                }

                sb.Append("</li>");
            }

            return sb.ToString();
        }

        #endregion
    }
}
