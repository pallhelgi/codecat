using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeCat.Startup))]
namespace CodeCat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
