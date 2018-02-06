using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedInfo_OOSD.Startup))]
namespace MedInfo_OOSD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
