using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WeiXinProject.EntityFrameworkCore
{
    public static class WeiXinProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WeiXinProjectDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WeiXinProjectDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
