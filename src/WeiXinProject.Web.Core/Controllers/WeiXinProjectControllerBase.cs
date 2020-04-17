using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WeiXinProject.Controllers
{
    public abstract class WeiXinProjectControllerBase: AbpController
    {
        protected WeiXinProjectControllerBase()
        {
            LocalizationSourceName = WeiXinProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
