using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WeiXinProject.Authorization;

namespace WeiXinProject
{
    [DependsOn(
        typeof(WeiXinProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WeiXinProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<WeiXinProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(WeiXinProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
