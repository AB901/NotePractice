﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLibraryForDotNetCore.UsePostgresql
{
    /// <summary>
    /// https://docs.microsoft.com/zh-cn/ef/core/miscellaneous/cli/dbcontext-creation
    /// </summary>
    public class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            //appsettings.json设置为“始终复制”
            var builder = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connection = configuration.GetConnectionString("Default");
            optionsBuilder.UseNpgsql(connection);

            return new TestDbContext(optionsBuilder.Options);
        }
    }
}
