using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chess.Web.Startup))]
namespace Chess.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
