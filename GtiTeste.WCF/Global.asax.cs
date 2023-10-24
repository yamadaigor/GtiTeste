using GtiTeste.WCF.App_Start;
using System;

namespace GtiTeste.WCF
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            InjecaoDependenciaConfig.RegistrarContainerInjecaoDependencia();
        }
    }
}