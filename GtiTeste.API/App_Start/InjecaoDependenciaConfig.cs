using GtiTeste.API.Utils;
using GtiTeste.Business.Interfaces;
using GtiTeste.Business.Interfaces.Repository;
using GtiTeste.Business.Interfaces.Services;
using GtiTeste.Business.Services;
using GtiTeste.Data.Data;
using GtiTeste.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace GtiTeste.API.App_Start
{
    public class InjecaoDependenciaConfig
    {
        public static void RegistrarContainerInjecaoDependencia()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            ResolverDependencias(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =  new SimpleInjectorWebApiDependencyResolver(container);
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