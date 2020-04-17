using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using WeiXinProject.MultiTenancy;

namespace WeiXinProject.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
