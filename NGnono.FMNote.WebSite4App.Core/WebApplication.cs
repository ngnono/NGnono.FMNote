using NGnono.FMNote.WebSite4App.Core.App_Start;
using NGnono.FMNote.WebSupport.Binder;
using NGnono.FMNote.WebSupport.Ioc;
using NGnono.Framework.Models;
using NGnono.Framework.ServiceLocation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NGnono.FMNote.WebSite4App.Core
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //self
            IocRegisterRun.Current.Register();
            DependencyResolver.SetResolver(ServiceLocator.Current.Resolve<IDependencyResolver>());
            ModelBinders.Binders.Add(typeof(PagerRequest), ServiceLocator.Current.Resolve<PagerRequestBinder>());
        }
    }
}
