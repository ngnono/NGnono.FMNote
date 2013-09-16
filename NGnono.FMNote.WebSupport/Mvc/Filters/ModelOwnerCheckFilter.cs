using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using NGnono.FMNote.WebSupport.Mvc.Controllers;

namespace NGnono.FMNote.WebSupport.Mvc.Filters
{
    public class NotModelOwnerException : Exception
    {
        public NotModelOwnerException()
            : base("该信息不属于当前登录用户")
        {
        }
    }

    /// <summary>
    /// 需要物主检查 Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ModelOwnerCheckAttribute : Attribute
    {
        /// <summary>
        /// 模型对象中获取CustomerId的属性名称
        /// </summary>
        private string _customerPropertyName = "CustomerId";

        /// <summary>
        /// CustomerId 属性名
        /// </summary>
        public string CustomerPropertyName
        {
            get { return _customerPropertyName; }
            set { _customerPropertyName = value; }
        }

        /// <summary>
        /// Action参数名
        /// </summary>
        public string TakeParameterName { get; set; }
    }

    /// <summary>
    /// 模型物主校验过滤器
    /// </summary>
    public class ModelOwnerCheckFilter : IActionFilter
    {
        /// <summary>
        /// Called before an action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var attbs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(ModelOwnerCheckAttribute), false);
            if (attbs.Length == 0) throw new ArgumentNullException("filterContext", "当前Action未定义ModelOwnerCheckAttribute");

            var controller = filterContext.Controller as UserController;
            if (null == controller) throw new ArgumentNullException("filterContext", "filterContext.Controller 未继承自 userhomecontroller");

            if (controller.CurrentUser == null) throw new Exception("未登录");

            var attb = attbs[0] as ModelOwnerCheckAttribute;
            if (attb == null)
            {
                throw new Exception("读取ModelOwnerCheckAttribute失败");
            }

            var param = String.IsNullOrWhiteSpace(attb.TakeParameterName)
                            ? filterContext.ActionParameters.First().Value
                            : filterContext.ActionParameters[attb.TakeParameterName];

            if (param == null)
            {
                // 如果参数为空则放弃校验
                return;

                // throw new ArgumentNullException("attb.TakeParameterName");
            }

            // parse CustomerId
            var propertyInfo = param.GetType().GetProperty(attb.CustomerPropertyName);
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("属性不存在:" + attb.CustomerPropertyName);
            }

            var customerid = propertyInfo.GetValue(param, null);

            // 防止不同Model customerid类型不同，按照字符串进行比较
            if (!customerid.ToString().Equals(controller.CurrentUser.CustomerId.ToString(CultureInfo.InvariantCulture)))
            {
                throw new NotModelOwnerException();
            }
        }

        /// <summary>
        /// Called after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}