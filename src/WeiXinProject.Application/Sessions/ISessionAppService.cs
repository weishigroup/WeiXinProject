using System.Threading.Tasks;
using Abp.Application.Services;
using WeiXinProject.Sessions.Dto;

namespace WeiXinProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
