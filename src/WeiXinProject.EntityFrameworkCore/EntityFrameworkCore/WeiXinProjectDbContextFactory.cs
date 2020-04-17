using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WeiXinProject.Configuration;
using WeiXinProject.Web;

namespace WeiXinProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WeiXinProjectDbContextFactory : IDesignTimeDbContextFactory<WeiXinProjectDbContext>
    {
        public WeiXinProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WeiXinProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WeiXinProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WeiXinProjectConsts.ConnectionStringName));

            return new WeiXinProjectDbContext(builder.Options);
        }
    }
}
