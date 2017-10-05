using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatingsiteSpice.Startup))]
namespace DatingsiteSpice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
