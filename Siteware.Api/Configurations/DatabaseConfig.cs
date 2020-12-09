using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var sqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>((serviceProvider) => new SqlConnection(sqlConnectionString));

        }
    }
}
