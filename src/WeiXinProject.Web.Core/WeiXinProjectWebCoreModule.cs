using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using WeiXinProject.Authentication.JwtBearer;
using WeiXinProject.Configuration;
using WeiXinProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using WeiXinProject.WxSdk;
using WeiXinProject.Authentication.External;

namespace WeiXinProject
{
    [DependsOn(
         typeof(WeiXinProjectApplicationModule),
        typeof(WeiXinProjectWxSdkModule),
         typeof(WeiXinProjectEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class WeiXinProjectWebCoreModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public WeiXinProjectWebCoreModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                WeiXinProjectConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();
            //CreateControllersForAppServices 方法接收一个程序集，把程序集里所有的应用服务转换为MVC控制器。你可以使用RemoteService特性在方法或类级别来启用/禁用它。
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(WeiXinProjectApplicationModule).GetAssembly()
                 );
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(WeiXinProjectWxSdkModule).GetAssembly()
                 );
            ConfigureTokenAuth();
            ConfigureExternalAuthProviders();
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public void ConfigureExternalAuthProviders()
        {
            IocManager.Register<ExternalLoginProviderInfo>();
            IocManager.Register<IExternalAuthConfiguration, ExternalAuthConfiguration>();
            var externalAuthConfiguration = IocManager.Resolve<ExternalAuthConfiguration>();
            if (bool.Parse(_appConfiguration["Authentication:EnterpriseWechat:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                       WechatAuthProviderApi.ProviderName,
                       _appConfiguration["Authentication:EnterpriseWechat:AppId"],
                       _appConfiguration["Authentication:EnterpriseWechat:Secret"],
                       typeof(WechatAuthProviderApi)
                    )
                );
            }
        }
        //初始化模块
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeiXinProjectWebCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(WeiXinProjectWebCoreModule).Assembly);
        }
    }
}
