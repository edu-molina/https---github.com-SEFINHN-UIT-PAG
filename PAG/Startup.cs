using Microsoft.Owin;
using Owin;
using SEFIN.FWK.STS.OWIN;

[assembly: OwinStartup(typeof(PAG.Startup))]

namespace PAG
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            app.UseSTS3();

        }
    }
}

