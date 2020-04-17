using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WeiXinProject.Authorization.Roles;
using WeiXinProject.Authorization.Users;
using WeiXinProject.MultiTenancy;

namespace WeiXinProject.EntityFrameworkCore
{
    public class WeiXinProjectDbContext : AbpZeroDbContext<Tenant, Role, User, WeiXinProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public WeiXinProjectDbContext(DbContextOptions<WeiXinProjectDbContext> options)
            : base(options)
        {
        }
    }
}
