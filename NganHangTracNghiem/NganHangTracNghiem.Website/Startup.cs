using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NganHangTracNghiem.Website.Startup))]
namespace NganHangTracNghiem.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
