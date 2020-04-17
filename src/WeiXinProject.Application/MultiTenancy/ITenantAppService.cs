using Abp.Application.Services;
using WeiXinProject.MultiTenancy.Dto;

namespace WeiXinProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

