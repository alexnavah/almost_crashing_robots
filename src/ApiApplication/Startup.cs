using Domain.Commands;
using Domain.Commands.Interfaces;
using Domain.Contexts;
using Domain.Data.Repositories;
using Domain.Data.Repositories.Interfaces;
using Domain.Queries;
using Domain.Queries.Interfaces;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CoreConnection"]));

            services.AddScoped<IGetStatisticsQuery, GetStatisticsQuery>();
            services.AddScoped<IValidateMissionCommand, ValidateMissionCommand>();
            services.AddScoped<IExecuteMissionCommand, ExecuteMissionCommand>();

            services.AddSingleton<IMissionInputRepository, MissionInputRepository>();
            services.AddSingleton<IMissionOutputRepository, MissionOutputRepository>();

            services.AddScoped<IMissionService, MissionService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
