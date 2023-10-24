using GtiTeste.Business.Interfaces;
using GtiTeste.Business.Interfaces.Repository;
using GtiTeste.Business.Interfaces.Services;
using GtiTeste.Business.Services;
using GtiTeste.Data.Data;
using GtiTeste.Data.Repository;
using GtiTeste.WCF.Utils;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Lifestyles;
using System.Reflection;

namespace GtiTeste.WCF.App_Start
{
    public class InjecaoDependenciaConfig
    {
        public static void RegistrarContainerInjecaoDependencia()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterWcfServices(Assembly.GetExecutingAssembly());

            ResolverDependencias(container);

            SimpleInjectorServiceHostFactory.SetContainer(container);

        }

        // Método onde as dependências serão "Registradas"
        public static void ResolverDependencias(Container container)
        {
            container.Register<GtiDbContext>(Lifestyle.Scoped);
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IEstadoRepository, EstadoRepository>(Lifestyle.Scoped);

            // Registra o IMapper como singleton para mapeamento de todoas as entidades/models
            container.RegisterSingleton(() => AutoMapperHelper.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}