using System.Collections.Generic;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSupport.Auth;
using NGnono.FMNote.WebSupport.Models;
using NGnono.Framework.Data.EF;
using NGnono.Framework.Models;
using NGnono.Framework.ServiceLocation;
using NGnono.Framework.Web.Mvc.Controllers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSupport.Mvc.Controllers
{
    public abstract class UserController : BaseController
    {
        #region fields

        private INGnono_FMNoteContextEFUnitOfWork _fmnoteUnitOfWork;

        #endregion

        protected UserController()
        {
            AuthenticationService = ServiceLocator.Current.Resolve<IAuthenticationService>();
        }

        #region properties

        private INGnono_FMNoteContextEFUnitOfWork FMNoteUnitOfWork
        {
            get { return _fmnoteUnitOfWork ?? (_fmnoteUnitOfWork = GetService<INGnono_FMNoteContextEFUnitOfWork>()); }
        }

        #endregion

        #region methods

        protected delegate IQueryable<TData> PagedListGetterHandler<TData>(INGnono_FMNoteContextEFUnitOfWork unitOfWork, Expression<Func<TData, bool>> filter, Func<IQueryable<TData>, IOrderedQueryable<TData>> orderby, PagerRequest pagerRequest, out int totalCount);

        protected PagerInfo<TData> PagedListGetter<TData, TFilterOptions, TOrderbyOptions>(PagerRequest pagerRequest, TFilterOptions filterOptions,
                                                          TOrderbyOptions orderbyOptions, PagedListGetterHandler<TData> getterHandler, Func<TFilterOptions, Expression<Func<TData, bool>>> filterConverter, Func<TOrderbyOptions, Func<IQueryable<TData>, IOrderedQueryable<TData>>> orderbyConverter)
        {
            int totalCount;
            IEnumerable<TData> datas;
            using (FMNoteUnitOfWork)
            {
                datas = getterHandler(FMNoteUnitOfWork, filterConverter == null ? null : filterConverter(filterOptions), orderbyConverter == null ? null : orderbyConverter(orderbyOptions), pagerRequest, out totalCount).ToList();
            }

            return new PagerInfo<TData>(pagerRequest, totalCount, datas);
        }

        protected delegate IQueryable<TData> ListGetterHandler<TData>(
            INGnono_FMNoteContextEFUnitOfWork unitOfWork, Expression<Func<TagEntity, bool>> filter,
            Func<IQueryable<TData>, IOrderedQueryable<TData>> orderby);

        protected IQueryable<TData> ListGetter<TData, TFilterOptions, TOrderbyOptions>(TFilterOptions filterOptions,
                                                  TOrderbyOptions orderbyOptions, ListGetterHandler<TData> getterHandler, Func<TFilterOptions, Expression<Func<TagEntity, bool>>> filterConverter, Func<TOrderbyOptions, Func<IQueryable<TData>, IOrderedQueryable<TData>>> orderbyConverter)
        {
            IQueryable<TData> datas;
            using (FMNoteUnitOfWork)
            {
                datas = getterHandler(FMNoteUnitOfWork, filterConverter == null ? null : filterConverter(filterOptions), orderbyConverter == null ? null : orderbyConverter(orderbyOptions));
            }

            return datas;
        }

        //protected delegate TData ItemSetterHandler<TData>(IFMNoteEFUnitOfWork unitOfWork, TData data);

        //protected TData ItemSetter<TData>(TData data, ItemSetterHandler<TData> setterHandler)
        //{
        //    TData newData;
        //    using (UnitOfWork)
        //    {
        //        newData = setterHandler(UnitOfWork, data);
        //    }

        //    return newData;
        //}

        protected TData ItemSetter<TData>(TData data, Func<INGnono_FMNoteContextEFUnitOfWork, TData, TData> func)
        {
            TData newData;
            using (FMNoteUnitOfWork)
            {
                newData = func(FMNoteUnitOfWork, data);
            }

            return newData;
        }

        private static readonly string IfmNoteEFUnitOfWork = typeof(INGnono_FMNoteContextEFUnitOfWork).Name;

        /// <summary>
        /// 是否是
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsServiceDefined(Type type)
        {
            return true;

            //if (type.Name.Equals(IfmNoteEFUnitOfWork))
            //{
            //    return true;
            //}

            //return false;
        }


        protected TOut ServiceInvoke<TUnitOfWork, TOut>(Func<TUnitOfWork, TOut> func)
        {
            if (IsServiceDefined(typeof(TUnitOfWork)))
            {
                var service = GetService<TUnitOfWork>();

                return Invoke(true, service, func);
            }

            throw new ArgumentException("TUnitOfWork No pre-defined. ");
        }

        protected void ServiceInvoke<TUnitOfWork>(Action<TUnitOfWork> action)
        {
            if (IsServiceDefined(typeof(TUnitOfWork)))
            {
                var service = GetService<TUnitOfWork>();

                Invoke(true, service, action);
            }
            else
            {
                throw new ArgumentException("TUnitOfWork No pre-defined. ");
            }
        }

        protected bool ServiceInvoke<TUnitOfWork>(Predicate<TUnitOfWork> predicate)
        {
            if (IsServiceDefined(typeof(TUnitOfWork)))
            {
                var service = GetService<TUnitOfWork>();

                return Invoke(true, service, predicate);
            }

            throw new ArgumentException("TUnitOfWork No pre-defined. ");
        }

        private static TOut Invoke<TIn, TOut>(bool autoDisposed, TIn service, Func<TIn, TOut> func)
        {
            if (autoDisposed)
            {
                var disposable = service as IDisposable;
                if (disposable != null)
                {
                    using (disposable)
                    {
                        return func(service);
                    }
                }
                throw new ArgumentException("service is not implement IDisposable");
            }

            return func(service);
        }

        private static void Invoke<TIn>(bool autoDisposed, TIn service, Action<TIn> action)
        {
            if (autoDisposed)
            {
                var disposable = service as IDisposable;
                if (disposable != null)
                {
                    using (disposable)
                    {
                        action(service);
                    }
                }
                else
                {
                    throw new ArgumentException("service is not implement IDisposable");
                }
            }
            else
            {
                action(service);
            }
        }

        private static bool Invoke<TIn>(bool autoDisposed, TIn service, Predicate<TIn> predicate)
        {
            if (autoDisposed)
            {
                var disposable = service as IDisposable;
                if (disposable != null)
                {
                    using (disposable)
                    {
                        return predicate(service);
                    }
                }
                throw new ArgumentException("service is not implement IDisposable");
            }

            return predicate(service);
        }

        protected T ServiceInvoke<T>(Func<INGnono_FMNoteContextEFUnitOfWork, T> func)
        {
            using (FMNoteUnitOfWork)
            {
                return func(FMNoteUnitOfWork);
            }
        }

        protected void ServiceInvoke(Action<INGnono_FMNoteContextEFUnitOfWork> action)
        {
            using (FMNoteUnitOfWork)
            {
                action(FMNoteUnitOfWork);
            }
        }

        protected bool ServiceInvoke(Predicate<INGnono_FMNoteContextEFUnitOfWork> predicate)
        {
            using (FMNoteUnitOfWork)
            {
                return predicate(FMNoteUnitOfWork);
            }
        }

        #endregion

        protected void SetAuthorize(WebSiteUser webSiteUser)
        {
            AuthenticationService.SetAuthorize(base.HttpContext, webSiteUser);
        }

        protected void Signout()
        {
            AuthenticationService.Signout(base.HttpContext);
        }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        private WebSiteUser _currentUser;

        /// <summary>
        /// Gets or sets AuthenticationService.
        /// </summary>
        public IAuthenticationService AuthenticationService { get; set; }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        public WebSiteUser CurrentUser
        {
            get { return _currentUser ?? (_currentUser = AuthenticationService.GetCurrentUser(base.HttpContext)); }
        }

        /// <summary>
        /// 禁用 Response
        /// </summary>
        [Obsolete]
        public new HttpResponseBase Response
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Response");
            }
        }

        /// <summary>
        /// 禁止直接使用Request
        /// </summary>
        [Obsolete]
        public new HttpRequestBase Request
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Request");
            }
        }

        /// <summary>
        /// 禁止直接使用Session
        /// </summary>
        [Obsolete]
        public new HttpSessionStateBase Session
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Session");
            }
        }

        /// <summary>
        /// 禁止直接使用HttpContext
        /// </summary>
        [Obsolete]
        public new HttpContextBase HttpContext
        {
            get
            {
                throw new NotSupportedException("禁止直接使用HttpContext");
            }
        }

        /// <summary>
        /// 禁止直接使用 ControllerContext.
        /// </summary>
        [Obsolete]
        public new ControllerContext ControllerContext
        {
            get
            {
                throw new NotSupportedException("禁止直接使用ControllerContext");
            }
        }

        /// <summary>
        /// 根据Ajax请求切换对应视图
        /// </summary>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <param name="viewNameForAjax">
        /// The view name for ajax.
        /// </param>
        /// <returns>
        /// the view
        /// </returns>
        protected ViewResult ViewWithAjax(string viewName, string viewNameForAjax)
        {
            return ViewWithAjax(viewName, viewNameForAjax, null);
        }

        /// <summary>
        /// 根据Ajax请求切换对应视图
        /// </summary>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <param name="viewNameForAjax">
        /// The partial view name.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The view.
        /// </returns>
        protected ViewResult ViewWithAjax(string viewName, string viewNameForAjax, object model)
        {
            return View(base.Request.IsAjaxRequest() ? viewNameForAjax : viewName, model);
        }

        /// <summary>
        /// 向摘要增加错误信息
        /// 使用@Html.ValidationSummary()在view中输出 
        /// </summary>
        /// <param name="errMessage">
        /// The err message.
        /// </param>
        protected void AppendErrorSummary(string errMessage)
        {
            ModelState.AddModelError("summary", errMessage);
        }

        protected ActionResult Success(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View("Success");
        }

        protected ActionResult Success(object model)
        {
            return View("Success", model);
        }

        protected JsonResult SuccessResponse()
        {
            return Json(new
            {
                Success = true
            });
        }

        protected JsonResult FailResponse()
        {
            return Json(new
            {
                Success = false
            });
        }

        public bool HasRightForCurrentAction()
        {
            var action = RouteData.Values["action"];
            var actionName = string.Empty;
            if (action != null)
                actionName = action.ToString();
            return HasRightForAction(actionName);
        }

        public bool HasRightForAction(string actionName)
        {
            string controllName = RouteData.Values["controller"].ToString();
            return HasRightForAction(controllName, actionName);

        }

        public bool HasRightForAction(string controller, string actionName)
        {

            return false;
            //if (string.IsNullOrEmpty(controller))
            //    controller = RouteData.Values["controller"].ToString();
            //if (string.IsNullOrEmpty(actionName))
            //    actionName = RouteData.Values["action"].ToString();
            //actionName = actionName.ToLower();
            //string controllName = controller.ToLower();
            //if (CurrentUser == null)
            //    return true;
            //int hasRoles = (int)CurrentUser.Role;
            //if ((hasRoles & (int)UserRole.Admin) == (int)UserRole.Admin)
            //    return true;
            ////check controll+action whether need authorize
            //bool needAuthroize = (from right in CmsV1Application.Current.RightsMap
            //                      select string.Concat(right.ControllName.ToLower()
            //                             , right.ActionName.ToLower())
            //                     ).Contains(string.Concat(controllName, actionName));
            //if (!needAuthroize)
            //    return true;
            //var result = (from role in CmsV1Application.Current.RoleRightMap
            //              from right in role.RoleAccessRights
            //              where (hasRoles & role.Val) == role.Val &&
            //                    right.AdminAccessRight != null &&
            //                     right.AdminAccessRight.ControllName.ToLower() == controllName &&
            //                    right.AdminAccessRight.ActionName.ToLower() == actionName
            //              select new { id = role.Id }
            //            ).FirstOrDefault();
            //return result != null;

        }

        [HttpGet]
        public virtual JsonResult AutoComplete(string name)
        {
            return Json(new[] { new { Name = String.Empty } }
                        , JsonRequestBehavior.AllowGet);
        }
    }
}
