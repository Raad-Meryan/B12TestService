using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace B12Test.EntityFrameworkCore
{
    public static class B12TestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<B12TestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<B12TestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
