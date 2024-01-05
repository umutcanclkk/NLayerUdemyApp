using Autofac;
using NLayer.Caching;
using NLayer.Core.IServices;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayerRepository;
using NLayerRepository.Repositories;
using NLayerRepository.UnitOfWorks;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayer.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // 1. GenericRepository ve Service sınıflarının kaydını yapar.
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            // 2. UnitOfWork sınıfının kaydını yapar.
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            // 3. API, Repository ve Service assembly'lerini alır.
            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));



            // 4. Repository sınıflarını kaydeder.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            // 5. Service sınıflarını kaydeder.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


            //builder.RegisterType<CategoryServiceWithCaching>().As<ICategoryService>();
            //builder.RegisterType<CustomersServiceWithCaching>().As<ICustomersService>();   /// bu methotlar Nlayer.Caching katmanını çalıştırıyor gerekli implementler yapılınca çalışır 
            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
            //builder.RegisterType<PaymentServiceWithCaching>().As<IPaymentService>();
        }
    }
}
