[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Sefin.CsProB.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Sefin.CsProB.WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace Sefin.CsProB.WebApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Logic;
    using Logic.Dal;
    using Commons;
    using Libs;

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
            kernel.Bind<CategoryServices>().ToSelf().InRequestScope();
            kernel.Bind<ProductServices>().ToSelf().InRequestScope();
            kernel.Bind<NorthwindContext>().ToSelf().InRequestScope();

            kernel.Bind<IAppContext>().To<WebApplicationContext>().InRequestScope();

            //kernel.Bind<Categories>().ToMethod(
            //    ctx => new Categories {
            //        Description = "Categoria nuova"
            //    }).InSingletonScope(); 
        }        
    }
}
