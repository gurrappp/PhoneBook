using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using PhoneBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Identity.Client;

//Microsoft.Extensions.Configuration.FileExtensions;

//Microsoft.Extensions.Configuration.Json;
namespace PhoneBook
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public string DbPath { get; }

        public PhoneBookContext()
        {

            DbPath = "";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            IConfigurationRoot configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var connectionString = configuration.GetConnectionString("DbContext");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

