using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NGnono.FMNote.Datas.Models;
using NGnono.FMNote.Repository;
using NGnono.FMNote.WebSupport.Auth;
using NGnono.Framework.Data;
using NGnono.Framework.Data.EF;
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
            Current.RegisterSingleton<ILog, CommonLogging>();

            Current.Register<IAuthenticationService, AuthenticationService>();

            Current.Register<INGnono_FMNoteContextEFUnitOfWork, NGnono_FMNoteContextUnitOfWork>();

            //response

            //Current.Register<IRepository<CategoryEntity, int>, EFRepository<CategoryEntity, int>>();
        }

        #endregion
    }
}
