using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Data
{
    public class DBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<AppDBContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new AppDBContext(builder.Options);
        }
    }
}
