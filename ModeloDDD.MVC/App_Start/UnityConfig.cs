using ModeloDDD.Application;
using ModeloDDD.Application.Interface;
using ModeloDDD.Domain.Interfaces.Repositories;
using ModeloDDD.Domain.Interfaces.Services;
using ModeloDDD.Domain.Services;
using ModeloDDD.Infra.Data.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ModeloDDD.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType < (typeof(IAppServiceBase<>)) , (typeof(AppServiceBase<>)) >typeof();
            container.RegisterType<IClienteAppService, ClienteAppService>();
            container.RegisterType<IProdutoAppService, ProdutoAppService>();

            // container.RegisterType<(typeof(IServiceBase<>)) , (typeof(ServiceBase<>))>();
            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<IProdutoService, ProdutoService>();

            // container.RegisterType<(typeof(IRepositoryBase<>)) , (typeof(RepositoryBase<>))>();
            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}