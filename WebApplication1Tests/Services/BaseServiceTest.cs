using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Contexts;

namespace WebApplication1Tests.Services
{
    public abstract class BaseTestService
    {
        public BaseTestService()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",
                    optional: false,
                    reloadOnChange: true);

            Configuration = builder.Build();

            Options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(Configuration.GetConnectionString("DbConnection"))
                .Options;
        }


        public IConfiguration Configuration { get; protected set; }
        public virtual DbContextOptions<DatabaseContext> Options { get; protected set; }
        public IServiceProvider ServiceProvider { get; protected set; }


        protected virtual void InitServices()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();

            RegisterServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }


        protected virtual void InitDbOptions(DbContextOptionsBuilder builder) =>
            builder.UseSqlServer(Configuration.GetConnectionString("DbConnection"));


        protected virtual void RegisterServices(ServiceCollection services)
        {
            //DependencyInjector.RegisterServices(services);
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<DatabaseContext>(options => InitDbOptions(options));
        }
    }
}

