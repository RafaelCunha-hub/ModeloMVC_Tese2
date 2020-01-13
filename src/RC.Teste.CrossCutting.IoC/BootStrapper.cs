using RC.Teste.Domain.Application;
using RC.Teste.Domain.Application.Interfaces;
using RC.Teste.Domain.Interfaces.Repository;
using RC.Teste.Domain.Interfaces.Services;
using RC.Teste.Domain.Services;
using RC.Teste.Infra.Data.Context;
using RC.Teste.Infra.Data.Interfaces;
using RC.Teste.Infra.Data.Repository;
using RC.Teste.Infra.Data.UnitOfWork;
using SimpleInjector;

namespace RC.Teste.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Dados
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<RCTesteContext>(Lifestyle.Scoped);
        }
    }
}
