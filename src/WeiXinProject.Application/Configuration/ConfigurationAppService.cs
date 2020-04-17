using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WeiXinProject.Configuration.Dto;

namespace WeiXinProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WeiXinProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
