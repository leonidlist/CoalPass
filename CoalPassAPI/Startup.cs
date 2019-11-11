using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoalPassBLL.DTO;
using CoalPassBLL.Services;
using CoalPassDAL.Abstractions;
using CoalPassDAL.Contexts;
using CoalPassDAL.Models;
using CoalPassDAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CoalPassAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public IHostingEnvironment Environment { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration = new ConfigurationBuilder()
                                    .AddJsonFile($"{Environment.ContentRootPath}/appsettings.json")
                                        .AddJsonFile($"{Environment.ContentRootPath}/appsettings.{Environment.EnvironmentName}.json")
                                            .Build();

            ConfigureWebApiControllers(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureWebApiControllers(IServiceCollection services)
        {
            services.AddSingleton(x => new MongoDbContext(Configuration.GetConnectionString("mongoDb")));
            services.AddSingleton<IAsyncRepository<User>, UsersRepository>();
            services.AddSingleton<IAsyncRepository<Password>, PasswordsRepository>();
            services.AddSingleton<IService<RecordDTO>, RecordsService>();
            services.AddSingleton<IService<UserDTO>, UsersService>();
        }
    }
}
