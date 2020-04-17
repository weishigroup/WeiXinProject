using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeiXinProject.Configuration;

namespace WeiXinProject.Web.Host.Startup
{
    [DependsOn(
       typeof(WeiXinProjectWebCoreModule))]
    public class WeiXinProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WeiXinProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeiXinProjectWebHostModule).GetAssembly());
        }
    }
}
