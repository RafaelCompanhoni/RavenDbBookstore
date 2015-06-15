using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Bookstore.Application;
using Bookstore.Domain.Interfaces;
using Bookstore.Persistence.Context;
using Bookstore.Persistence.DataAccess;
using Bookstore.Persistence.DataAccess.Repositories;
using Bookstore.Web.IoC;
using Raven.Client;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AutofacMvcConfig), "AutofacConfig")]
namespace Bookstore.Web.IoC
{
    public class AutofacMvcConfig
    {
        public static void AutofacConfig()
        {
            var builder = new ContainerBuilder();
            
            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            RegisterAppDependecies(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterAppDependecies(ContainerBuilder builder)
        {
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Repository, UoW e Service
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerRequest();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

            // Inicializa a sessão do RavenDb
            builder.Register<IDocumentSession>(b =>
            {
                var documentStore = new BookstoreDocumentStore();
                return documentStore.DocumentStore.OpenSession();

            }).InstancePerRequest();
        }
    }
}
