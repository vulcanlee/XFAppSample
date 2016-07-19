using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DoggyMobileBEService.Startup))]

namespace DoggyMobileBEService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}