using System.Threading.Tasks;
using WeiXinProject.Configuration.Dto;

namespace WeiXinProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
