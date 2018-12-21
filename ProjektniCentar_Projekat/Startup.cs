using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektniCentar_Projekat.Startup))]
namespace ProjektniCentar_Projekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
