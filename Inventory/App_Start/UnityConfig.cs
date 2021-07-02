using Backend.Repositories;
using Inventory.Service;
using System.Web.Http;
using Unity;


namespace Inventory.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IProductService, ProductService>();

            return container;
        }
    }
}