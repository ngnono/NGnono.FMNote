using NGnono.FMNote.WebSupport.Auth;
using NGnono.FMNote.WebSupport.Models;
using NGnono.FMNote.WebSupport.Mvc.Controllers;
using NGnono.Framework.Logger;
using NGnono.Framework.Models;
using NGnono.Framework.ServiceLocation;
using NGnono.Framework.Web.Mvc.ActionResults;
using System;
using System.Web;
using System.Web.Mvc;

namespace NGnono.FMNote.WebSupport.Mvc.Filters
{
    public class LoginAuthorizeAttribute : AuthorizeAttribute
    {
        private WebSiteUser _webSiteUser;
        private static readonly ILog _log;

        static LoginAuthorizeAttribute()
        {
            _log = LoggerManager.Current();
        }

        protected virtual void ExecOnAuthorization(AuthorizationContext filterContext)
        {
            switch (filterContext.HttpContext.Response.StatusCode)
            {
                case 400:
                    filterContext.HttpContext.ClearError();
                    filterContext.Result = new HttpUnauthorizedResult("您还没有登录");
                    break;
                case 401:
                    filterContext.HttpContext.ClearError();
                    //if (filterContext.HttpContext.Response.SubStatusCode == 1)
                    //{
                    filterContext.Result = new HttpUnauthorizedResult("您的身份认证失败");

                    break;
                //}
                case 402:
                    filterContext.HttpContext.ClearError();
                    //if (filterContext.HttpContext.Response.SubStatusCode == 2)
                    //{
                    filterContext.Result = new RestfulResult()
                    {
                        Data = new ExecuteResult()
                        {
                            StatusCode = StatusCode.Unauthorized,
                            Message = "您已经很长时候没有使用啦,为保证你的账户安全,请重新登录."
                        }
                    };
                    break;
                //}
                default:
                    break;
            }
        }

        protected virtual bool ExecAuthorizeCore(HttpContextBase httpContext)
        {
            //获取SessionKey
            //var token = httpContext.Request[Define.Token];

            var authenticationService = ServiceLocator.Current.Resolve<IAuthenticationService>();

            if (!authenticationService.Islogged(httpContext))
            {
                httpContext.Response.StatusCode = 400;
                return false;
            }

            //验证用户信息
            try
            {
                _webSiteUser = authenticationService.GetCurrentUser(httpContext);
            }
            catch (Exception ex)
            {
                _log.Error(String.Format("{0}获取websiteuser失败,Ex.M{1},Ex.S{2} ", httpContext.User.Identity.Name, ex.Message, ex.StackTrace));
            }

            // 解密失败返回结果
            if (_webSiteUser == null)
            {
                httpContext.Response.StatusCode = 401;
                //httpContext.Response.SubStatusCode = 1;

                return false;
            }

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            //override authorization logic here
            DoAuthorization(filterContext);

            ExecOnAuthorization(filterContext);
        }

        protected virtual void DoAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            var authenticationService = ServiceLocator.Current.Resolve<IAuthenticationService>();

            if (!authenticationService.Islogged(httpContext))
            {
                httpContext.Response.StatusCode = 400;
                return;
            }

            //验证用户信息
            try
            {
                _webSiteUser = authenticationService.GetCurrentUser(httpContext);
            }
            catch (Exception ex)
            {
                _log.Error(String.Format("{0}获取websiteuser失败,Ex.M{1},Ex.S{2} ", httpContext.User.Identity.Name, ex.Message, ex.StackTrace));
            }

            // 解密失败返回结果
            if (_webSiteUser == null)
            {
                httpContext.Response.StatusCode = 401;
                //httpContext.Response.SubStatusCode = 1;

                return;
            }
            //authorize
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionNae = filterContext.ActionDescriptor.ActionName;
            UserController currentController = filterContext.Controller as UserController;
            if (currentController == null)
                return;
            //if (!currentController.HasRightForAction(controllerName, actionNae))
            //{
            //    httpContext.Response.StatusCode = 401;
            //    return;
            //}

        }
    }
}
