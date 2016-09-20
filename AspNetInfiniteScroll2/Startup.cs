using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetInfiniteScroll2.Startup))]
namespace AspNetInfiniteScroll2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
