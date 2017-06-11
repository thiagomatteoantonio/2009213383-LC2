[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PaqueteTuristico.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(PaqueteTuristico.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace PaqueteTuristico.MVC.App_Start
{
    using System;
    using System.Web;
    using PaquetesTuristicos.Entities.IRepositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using PaquetesTuristicos.Persistence;
    using PaquetesTuristicos.Persistence.Repositories;
    using Ninject.Web.Common;
    using Ninject;

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
            //UnityOfWork
            kernel.Bind<IUnityofWork>().To<UnityofWork>();


            //PaqueteTuristicoDbContext
            kernel.Bind<PaqueteTuristicoDbContext>().To<PaqueteTuristicoDbContext>();

            //AlimentacionRepository
            kernel.Bind<IAlimentacionRepository>().To<AlimentacionRepository>();
            //ClienteRepository
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            //ComprobantePagoRepository
            kernel.Bind<IComprobantePagoRepository>().To<ComprobantePagoRepository>();
            //EmpleadoRepository
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            //HospedajeRepository
            kernel.Bind<IHospedajeRepository>().To<HospedajeRepository>();
            //PaqueteRepository
            kernel.Bind<IPaqueteRepository>().To<PaqueteRepository>();
            //TransporteRepository
            kernel.Bind<ITransporteRepository>().To<TransporteRepository>();
            //VentaPaqueteRepository
            kernel.Bind<VentaPaqueteRepository>().To<VentaPaqueteRepository>();
        }
    }
}
