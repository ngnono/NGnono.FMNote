using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.Framework.Logger;
using NGnono.Framework.Web.Mvc.Ioc;

namespace NGnono.FMNote.WebSupport.Ioc
{
    internal class ImportantSupportIocRegister : BaseIocRegister
    {
        #region Overrides of BaseIocRegister

        public override void Register()
        {
            Current.Register<IControllerActivator, CustomControllerActivator>();
            Current.Register<IDependencyResolver, IocDependencyResolver>();
            //Current.RegisterSingleton<ILog, Log4NetLog>();
        }

        #endregion
    }
}
