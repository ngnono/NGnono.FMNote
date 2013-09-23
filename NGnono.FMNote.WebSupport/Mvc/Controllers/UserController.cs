using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSupport.Auth;
using NGnono.FMNote.WebSupport.Models;
using NGnono.Framework.ServiceLocation;
using NGnono.Framework.Web.Mvc.Controllers;
using System;
using System.Web;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSupport.Mvc.Controllers
{
    public abstract class UserController : BaseController
    {
        #region fields

        private IFMNoteEFUnitOfWork _unitOfWork;

        #endregion

        protected UserController()
        {
            AuthenticationService = ServiceLocator.Current.Resolve<IAuthenticationService>();
        }

        #region properties

        protected IFMNoteEFUnitOfWork UnitOfWork
        {
            get { return _unitOfWork ?? (_unitOfWork = GetService<IFMNoteEFUnitOfWork>()); }
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
            return Json(new[] { new { Name = string.Empty } }
                        , JsonRequestBehavior.AllowGet);
        }
    }
}
