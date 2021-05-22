using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Site_za_evidenciju_radnih_sati.Startup))]
namespace Site_za_evidenciju_radnih_sati
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
