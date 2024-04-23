using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class SQLHelper
    {
        private string connectionString;
        public SQLHelper()
        {
            //IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            //IConfigurationRoot configuration = builder.Build();
            IConfigurationRoot configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            connectionString = configuration.GetConnectionString("DbContext") ?? "";
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
