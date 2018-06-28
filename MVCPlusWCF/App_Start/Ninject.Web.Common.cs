[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVCPlusWCF.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVCPlusWCF.App_Start.NinjectWebCommon), "Stop")]

namespace MVCPlusWCF.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MVCPlusWCF.BLL;
    using MVCPlusWCF.Mappers;
    using MVCPlusWCF.Models;
    using MVCPlusWCF.ServiceMappers;
    using MVCPlusWCF.Services;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserMapper>().To<UserMapper>();
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IAdminDataService>().To<AdminDataService>();
            kernel.Bind<IUserDataService>().To<UserDataService>();
            kernel.Bind<IDataFromRole>().To<DataFromRole>();
            kernel.Bind<IUserConverter>().To<UserConverter>();
        }        
    }
}