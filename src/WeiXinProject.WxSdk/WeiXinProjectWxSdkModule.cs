using System;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WeiXinProject.WxSdk
{
    public class WeiXinProjectWxSdkModule :AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WeiXinProjectWxSdkModule).GetAssembly());
        }

    }
}
